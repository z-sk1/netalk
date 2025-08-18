import React, { useState, useRef, useEffect } from 'react';
import { View, Text, StyleSheet, TextInput, TouchableOpacity, ScrollView, Alert, Switch } from 'react-native';
import { styles } from '../App'; 
import { useConnection } from '../ConnectionContext';
import { useUser } from '../UserContext';

export default function ChatTab() {
    const [txtChat, setTxtChat] = useState('');
    const [txtChatFocused, setTxtChatFocused] = useState(false);
    const [btnSendPressed, setBtnSendPressed] = useState(false);
    const [isPrivate, setIsPrivate] = useState(false);
    const { isConnected, client } = useConnection();
    const [messages, setMessages] = useState([]);
    const { userList, setUserList, username, setUsername } = useUser();
    const [receiverName, setReceiverName] = useState(null);
    const [receiverTxtFocused, setReceiverTxtFocused] = useState(false);

    const scrollRef = useRef();

    function updateUserList(listContent) {
        setUserList(listContent.split(',').map(u => u.trim()));
    }

    useEffect(() => {
        scrollRef.current?.scrollToEnd({ animated: true });
    }, [messages]);

    function appendMsg(a, msg) {
        a(prevMessages => [...prevMessages, msg])
    }

    useEffect(() => {
        if (!isConnected || !client) return;

        const handleData = (data) => {
            const msg = data.toString('utf8');
            const lines = msg.split('\n');

            lines.forEach(m => {
                const trimmed = m.trim();
                if (!trimmed) return;
                
                if (trimmed == "Enter your username:") {
                    let usernameToSend = username.trim() || "Guest";
                    client.write(usernameToSend, "\n");
                    return;
                }

                if (trimmed.startsWith("/list")) {
                    const listContent = trimmed.substring(5).trim();
                    appendMsg(setUserList, listContent)
                } else {
                    appendMsg(setMessages, trimmed);
                }
            });
        };

        client.on('data', handleData);

        const handleClose = () => appendMsg(setMessages, "Disconnected from server");
        const handleError = (err) => appendMsg(setMessages, "Error: " + err.message);

        client.on('close', handleClose);
        client.on('error', handleError);

        return () => {
            client.off('data', handleData);
            client.off('close', handleClose);
            client.off('error', handleError);
        };
    }, [client]);

    function sendMsg() {
        if (!isConnected || !client) {
            Alert.alert("Not connected", "Please connect in settings first!");
            return;
        }

        const msg = txtChat.trim();

        if (!msg) {
            Alert.alert("Nothing to send", "Type something first!");
            return;
        }

        try {
            if (isPrivate) {
                const whisperCmd = "/whisper"
                client.write(whisperCmd + " " + receiverName + " " + msg + "\n")
            } else {
                client.write(msg + "\n");
            }
            setTxtChat("");
        } catch (err) {
            Alert.alert("Send failed:", err.message);
        }
    }

    return (
        <View style = {styles.container}>
            <Text style = {styles.h1}>netalk</Text>
            <Text style = {styles.h2}>
                {isPrivate ? "Private Messages" : "Public Messages"}
            </Text>

            <View style = {styles.inputGroup}>
                {isPrivate ? (
                    <>
                        <TextInput 
                            style = {[styles.textInput, receiverTxtFocused && styles.textInputFocused]}
                            placeholder = "Type in your receiver's user..."
                            onFocus = {(() => setReceiverTxtFocused(true))}
                            onBlur = {(() => setReceiverTxtFocused(false))}
                            value = {receiverName}
                            onChangeText = {setReceiverName}
                        />
                        <TextInput 
                            style = {[styles.textInput, txtChatFocused && styles.textInputFocused]}
                            placeholder = "Type in your private message..."
                            onFocus = {(() => setTxtChatFocused(true))}
                            onBlur = {(() => setTxtChatFocused(false))}
                            value = {txtChat}
                            onChangeText = {setTxtChat}
                        />
                    </>
                ) : (
                    <TextInput
                        style = {[styles.textInput, txtChatFocused && styles.textInputFocused]}
                        placeholder = "Type in your message..."
                        onFocus = {(() => setTxtChatFocused(true))}
                        onBlur = {(() => setTxtChatFocused(false))}
                        value = {txtChat}
                        onChangeText = {setTxtChat}
                    />
                )}

                <View style = {styles.buttonToggleRow}>
                    <TouchableOpacity
                        style = {[styles.sendbutton, btnSendPressed && styles.buttonPressed]}
                        onPressIn = {(() => setBtnSendPressed(true))}
                        onPressOut = {(() => setBtnSendPressed(false))}
                        onPress = {sendMsg}>
                        <Text style = {styles.buttonText}>Send</Text>
                    </TouchableOpacity>

                    <View style = {styles.toggleContainer}>
                        <Switch
                            value = {isPrivate}
                            onValueChange = {(val) => {
                                setIsPrivate(val);
                            }}
                        />
                        <Text style = {styles.toggleLabel}>Private</Text>
                    </View>
                </View>

                <ScrollView ref={scrollRef} style={styles.chatBox}>
                    {messages.map((m, i) => (
                        <Text key={i}>{m}</Text>
                    ))}
                </ScrollView>

            </View>
        </View>
    );
}