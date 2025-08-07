# 🗨️ Netalk – P2P LAN Chat Service

**Netalk** is a lightweight chat service designed for local network communication between Windows devices. It's powered by a Go-based backend and a modern .NET Windows Forms frontend.

---

## 📦 Features

- Local peer-to-peer chat with minimal setup
- Simple, clean Windows desktop client
- Self-hosted backend with a single `go run` or `.exe` file
- Designed for small teams, LAN parties, or offline communication

---

## 🚀 Getting Started

### 🖥️ For End Users

1. **Download the packaged release** (Client + Backend).
2. **Download LogMeIn Hamachi** from the official site, https://vpn.net/.
> If the site is currently not responding or unavailable, you can use this 3rd Party download from Softpedia. https://www.softpedia.com/get/Internet/File-Sharing/Hamachi.shtml
3. **Run `Netalk.exe`** to open the chat client.
4.  **Run `run-netalk-server.bat`** to run the backend.
5. Set up a connection using a shared IP (e.g. via **LogMeIn Hamachi**).
6. Copy the IPV4 address (Its usually at the top of Hamachi, with a string of numbers like 25.2.11.2)
7. Paste the address into the IP Address text box into the top right of the client and click **Connect**.
8. Start chatting!

> Make sure everyone is connected to the same Hamachi network or LAN and has inputted the same **IP Address** into the text box.

---

### 🛠️ For Developers

1. Install **Go** from [https://go.dev](https://go.dev)
2. Clone this repo:
   ```bash
   git clone https://github.com/your-username/netalk.git
Run the backend:
cd server/ChatServer
go run main.go
Open ChatClient.sln in Visual Studio and build the solution.

## 🕸️ Connectivity
Netalk uses LAN IPs for connections. For remote setups:

Use LogMeIn Hamachi (recommended)

Or port forward your backend and share your IP

## 📸 Setup Instructions with Screenshots
Coming soon...

## 🤝 Contributing
Pull requests are welcome! If you’d like to suggest improvements or fixes, feel free to fork the project and submit a PR.



