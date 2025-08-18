import React, { useState, useEffect, useRef } from 'react';
import TcpSocket from 'react-native-tcp-socket';
import { View, Text, StyleSheet, TouchableOpacity, TextInput, Alert } from 'react-native';
import { styles } from '../App'; 
import { useConnection } from '../ConnectionContext';
import { useUser } from '../UserContext';

export default function SettingsTab() {
    const [btnConnectTxt, setBtnConnectTxt] = useState("Connect");
    const [btnConnectPressed, setBtnConnectPressed] = useState(false);
    const [txtIP, setTxtIP] = useState('');
    const [txtIPFocused, setTxtIPFocused] = useState(false);
    const { isConnected, setIsConnected, client, setClient } = useConnection();
    const { userList, setUserList, username, setUsername } = useUser();

    return (
        <View style = {styles.container}>
            <Text style = {styles.h1}>netalk</Text>
            
            <View style = {styles.inputGroup}>
                <TextInput
                    style = {[styles.textInput, txtIPFocused && styles.textInputFocused]}
                    placeholder = "Enter the IP Address..."
                    onFocus = {(() => setTxtIPFocused(true))}
                    onBlur = {(() => setTxtIPFocused(false))}
                    value = {txtIP}
                    onChangeText = {setTxtIP}
                />

                <TouchableOpacity
                style = {[styles.button, btnConnectPressed && styles.buttonPressed]}
                onPressIn = {(() => setBtnConnectPressed(true))}
                onPressOut = {(() => setBtnConnectPressed(false))}
                onPress = {connect}>
                <Text style = {styles.buttonText}>{btnConnectTxt}</Text>
                </TouchableOpacity>
            </View>
        </View>
    );

    function connect() {
        let serverIP = txtIP.trim()

        if (!serverIP) {
            Alert.alert("Please enter a valid IP Address first. e.g(25.9.1.53)");
            return;
        }

        // validate as IPv4 address
        const ipv4Pattern = /^(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}$/;
        if (!ipv4Pattern.test(serverIP)) {
            Alert.alert("Please enter a valid IP Address first. e.g(25.9.1.53");
            return;
        }

        if (btnConnectTxt === "Connect") {

            try {
                const tcpClient = TcpSocket.createConnection({ host: serverIP, port: 12345 }, () => {
                    console.log('Connected to server at:', serverIP, ". On port :12345.");
                    setClient(tcpClient);

                    // send username
                    let usernameToSend = username.trim() || "Guest";
                    tcpClient.write(usernameToSend + "\n");

                    // reqeust user list
                    tcpClient.write("/list\n");

                    // Listen for data
                    tcpClient.on('data', (data) => {
                        console.log('Received', data.toString());
                    });

                    // Handle error
                    tcpClient.on('error', (err) => {
                        console.error('Socket error', err);
                        Alert.alert("Connection error", err.message);
                    });

                    // Handle close
                    tcpClient.on('close', () => {
                        console.log('Connection closed');
                        setBtnConnectTxt("Connect")
                    });
                });

            setIsConnected(true);
            setBtnConnectTxt("Connected!");
            setTimeout(() => setBtnConnectTxt("Disconnect"), 1500);
        } catch (err) {
            Alert.alert("Error connecting:", err.message);
        } 
        } else if (btnConnectTxt === "Disconnect") {
            client?.destroy();

            setIsConnected(false);
            setBtnConnectTxt("Diconnected!");
            setTimeout(() => setBtnConnectTxt("Connect"), 1500);
        }

        useEffect(() => {
            let listInterval;

            if (btnConnectTxt === "Disconnect") {
                listInterval = setInterval(() => {
                    client?.write("/list\n");
                }, 1500);
            }

            return () => clearInterval(listInterval);
        }, [btnConnectTxt]);

    }
}