import React, { createContext, useContext, useState } from 'react';
import TcpSocket from 'react-native-tcp-socket';

const ConnectionContext = createContext();

export function ConnectionProvider({ children }) {
    const [isConnected, setIsConnected] = useState(false);
    const [client, setClient] = useState(null); // store TCP client

    return (
        <ConnectionContext.Provider value={{ isConnected, setIsConnected, client, setClient }}>
            {children}
        </ConnectionContext.Provider>
    );
}

export function useConnection() {
    return useContext(ConnectionContext);
}
