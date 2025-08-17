import React, { useState, useEffect, useRef } from 'react';
import { View, Text, StyleSheet, TextInput, TouchableOpacity, Alert } from 'react-native';
import { styles } from '../App';

export default function UsersTab() {
    const { userList, setUserList , username, setUsername } = useUser();
    const { isConnected, client } = useConnection();
    const [usernameInputFocused, setUsernameInputFocused] = useState(false);
    const [changeBtnPressed, setChangeBtnPressed] = useState(false);
    const [changeBtnTxt, setChangeBtnTxt] = useState("Change");
    const [newUsername, setNewUsername] = useState(username);

    const scrollRef = useRef();

    useEffect(() => {
        scrollRef.current?.scrollToEnd({ animated: true });
    }, [messages]);

    const refreshList = () => {
        if (isConnected && client) {
            setUserList([]); // clear the current list

            const listData = "/list\n";
            client.write(listData);
        }
    };

    useEffect(() => {
        const intervalId = setInterval(() => {
            refreshList();
        }, 1500); // every 5 seconds, adjust to match C# timer interval
        return () => clearInterval(intervalId); // cleanup on unmount
    }, [isConnected]);

    function changeUsername() {
        let user = newUsername.trim();
        
        if (!user) {
            Alert.alert("Please enter a username first.")
            return;
        }

        if (!isConnected || !client) {
            Alert.alert("Please connected first in the settings tab!")
            return;
        }

        setUsername(user);
        const renameCmd = "/rename: " + user;
        client.write(renameCmd + "\n"); 

        setChangeBtnTxt("Changed!")
        setTimeout(() => setChangeBtnTxt("Change"), 1500)
    }

    return (
        <View style = {styles.container}>
            <Text style = {styles.h1}>netalk</Text>
            
            <View style = {styles.inputGroup}>
                <TextInput
                    style = {[styles.textInput, usernameInputFocused && styles.textInputFocused]}
                    placeholder = "Guest, Enter a new username"
                    onFocus = {(() => setUsernameInputFocused(true))}
                    onBlur = {(() => setUsernameInputFocused(false))}
                    value = {newUsername}
                    onChangeText = {setNewUsername}
                />

                <TouchableOpacity
                    style = {[styles.button, changeBtnPressed && styles.buttonPressed]}
                    onPressIn = {(() => setChangeBtnPressed(true))}
                    onPressOut = {(() => setChangeBtnPressed(false))}
                    onPress = {changeUsername}>
                    <Text style = {styles.buttonText}>{changeBtnTxt}</Text>
                </TouchableOpacity>

                <ScrollView ref={scrollRef} style={styles.chatBox}>
                    {userList.map((u, i) => (
                        <Text key={i}>{u}</Text>
                    ))}
                </ScrollView>
            </View>


        </View>
    );
}