package main

import (
	"bufio"
	"fmt"
	"net"
	"strings"
)

var clients = make(map[net.Conn]string)

func main() {
	fmt.Println("Netalk backend starting...")

	listener, err := net.Listen("tcp", ":12345")
	if err != nil {
		panic(err)
	}
	defer listener.Close()

	for {
		conn, err := listener.Accept()
		if err != nil {
			fmt.Println("Error accepting connection:", err)
			continue
		}
		fmt.Println("connected to server")

		go handleConnection(conn)
	}
}

func handleConnection(conn net.Conn) {
	defer conn.Close()

	conn.Write([]byte("Enter your username:"))
	reader := bufio.NewReader(conn)
	username, err := reader.ReadString('\n')
	if err != nil {
		conn.Close()
		return
	}

	username = strings.TrimSpace(username)

	clients[conn] = username

	fmt.Printf("%s has joined the chat.\n", username)

	for c := range clients {
		if c != conn {
			c.Write([]byte(fmt.Sprintf("%s has joined the chat.\n", username)))
		}
	}

	conn.Write([]byte(fmt.Sprintf("Welcome, %s!\n", username)))

	for {
		msg, err := reader.ReadString('\n')
		if err != nil {
			for c := range clients {
				if c != conn {
					c.Write([]byte(fmt.Sprintf("%s has left the chat.\n", username)))
				}
			}
			delete(clients, conn)
			fmt.Println("Client disconnected:", username)
			return
		}

		cleanMsg := strings.TrimSpace(msg)

		if cleanMsg == "/quit" {
			conn.Write([]byte("Goodbye!\n"))
			fmt.Printf("%s has left the chat.\n", username)
			delete(clients, conn)
			return
		}

		if cleanMsg == "/list" {
			conn.Write([]byte("/list Users online:\n"))
			for _, name := range clients {
				conn.Write([]byte(fmt.Sprintf("/list - %s \n", name)))
			}
			continue
		}

		if strings.HasPrefix(cleanMsg, "/whisper ") {
			parts := strings.SplitN(cleanMsg, " ", 3)
			if len(parts) < 3 {
				conn.Write([]byte("Usage: /whisper <username> <message>\n"))
				continue
			}

			targetName := parts[1]
			message := parts[2]
			found := false

			for c, name := range clients {
				if name == targetName {
					c.Write([]byte(fmt.Sprintf("[whisper from %s] %s\n", username, message)))
					conn.Write([]byte(fmt.Sprintf("[whisper to %s] %s\n", targetName, message)))
					found = true
					break
				}
			}

			if !found {
				conn.Write([]byte("User not found. \n"))
			}

			continue

		}

		if strings.HasPrefix(cleanMsg, "/rename:") {
			newName := strings.TrimSpace(strings.TrimPrefix(cleanMsg, "/rename:"))
			for c := range clients {
				if c != conn {
					c.Write([]byte(fmt.Sprintf("%s is now known as %s.", username, newName)))
				}
			}
			username = newName

			continue
		}

		if cleanMsg == "/help" {
			conn.Write([]byte("All commands:\n"))
			conn.Write([]byte("/quit: Quits the chat service.\n"))
			conn.Write([]byte("/list: Lists all the online users.\n"))
			conn.Write([]byte("/whisper: Sends a private message to a specific user. Usage: /whisper <username> <message>\n"))
			conn.Write([]byte("/rename: Changes your username. Usage: /rename: <new username>"))

			continue
		}

		fmt.Println(username, "says:", cleanMsg)

		for c := range clients {
			if c != conn {
				c.Write([]byte(fmt.Sprintf("[%s] %s\n", username, cleanMsg)))
			} else {
				conn.Write([]byte(fmt.Sprintf("[you] %s\n", cleanMsg)))
			}
		}
	}
}
