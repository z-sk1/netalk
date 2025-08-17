import React, { createContext, useContext, useState } from 'react';
import TcpSocket from 'react-native-tcp-socket';

const UserContext = createContext();

export function UserProvider({ children }) {
    const [userList, setUserList] = useState([]);
    const [username, setUsername] = useState("Guest");

    return (
        <UserContext.Provider value={{ userList, setUserList , username, setUsername }}>
            {children}
        </UserContext.Provider>
    );
}

export function useUser() {
    return useContext(UserContext);
}