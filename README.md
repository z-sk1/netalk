# 🗨️ Netalk – P2P LAN Chat Service

**Netalk** is a lightweight chat service designed for local network communication between Windows devices. It uses a Go-based backend and a modern .NET Windows Forms frontend.

---

## 📦 Features

- Local peer-to-peer chat with minimal setup  
- Simple, clean Windows desktop client  
- Self-hosted backend (`go run` or `.exe`)  
- Perfect for small teams, LAN parties, or offline communication  

---

## 🚀 Getting Started

### 🖥️ End Users

1. **Download the packaged release** (Client + Backend).  
2. **Install a VPN if needed**:  
   - [LogMeIn Hamachi](https://vpn.net/)
  
     This is for those who need only PC support and are looking for an easy setup. The free tier of **Hamachi** is limited and supports only 5 devices per network at a time.
   - **OR** [ZeroTier](https://www.zerotier.com/)
  
     This is for those who need PC/Mobile connectivity and dont mind a slightly more difficult setup to gain more functionality and support.

3. **Run the client**:  
NetalkClient.exe

4. **Host the server** (only **one person** per chat group):  
 - **`netalk-server.exe`**
 - Locate your **IPv4 IP Address** via ZeroTier or Hamachi.
 - Share the IP with your peers.

6. **Connect via IP**:  
- Copy the host’s IPv4 from Hamachi or ZeroTier  
- Paste it into the **IP Address** textbox in the top-right of the client  
- Click **Connect**  

> ⚠️ Only one person should host `netalk-server.exe` at a time.  
> Make sure all users are on the same Hamachi or ZeroTier network.
> Only people with PCs can host.

6. Start chatting!

---

### 🛠️ For Developers

1. Install **Go** from [https://go.dev](https://go.dev)  
2. Clone the repository:
```
git clone https://github.com//netalk.git
```
3. Run the backend:
```
cd server/ChatServer
go run main.go
```
Open ChatClient.sln in Visual Studio and build the solution.

---
# 🌐 Connectivity Options
### LAN: Connect directly via local IPv4

### Hamachi: Recommended for easy virtual LAN setup

### ZeroTier: Alternative VPN for cross-network connections

---
# 📸 Setup Instructions with Screenshots
Coming soon...

---
# 🤝 Contributing
Pull requests are welcome! Suggest improvements or fixes by forking the project and submitting a PR.

---
# ⚖️ License
This project is licensed under the MIT License.




