# 🗨️ Netalk – P2P LAN Chat Service

**Netalk** is a lightweight chat service designed for local network communication between Windows devices. It uses a Go-based backend and a modern .NET Windows Forms frontend.

---

## 📦 Features

- Local peer-to-peer chat with minimal setup  
- Simple, clean Windows desktop client  
- Self-hosted backend (`go run` or `.exe`)  
- Perfect for small teams, LAN parties, or offline communication  

---

## Installation

### Windows:
1. **Download the packaged release** (Client + Backend).

2. **Install a VPN if needed**:  
   - [LogMeIn Hamachi](https://vpn.net/) if that link doesnt work, [LogMeIn Hamachi Alt](https://www.softpedia.com/get/Internet/File-Sharing/Hamachi.shtml)
  
     This is for those who need only PC support and are looking for an easy setup. The free tier of **Hamachi** is limited and supports only 5 devices per network at a time.
   - **OR** [ZeroTier](https://www.zerotier.com/)
  
     This is for those who need PC/Mobile connectivity and dont mind a slightly more difficult setup to gain more functionality and support.

3. **Run the client**:  
NetalkClient.exe

4. **Host the server** (only **one person** per chat group):  
 - **`netalk-server.exe`** if you're on Windows. **`netalk-backend-macos-intel`** if you're on an Intel Mac. And **`netalk-backend-macos-arm`** if you're on a Mac with Apple Silicon.
 - Locate your **IPv4 IP Address** via ZeroTier or Hamachi.
 - Share the IP with your peers.

5. **Connect via IP**:  
- Copy the host’s IPv4 from Hamachi or ZeroTier  
- Paste it into the **IP Address** textbox in the top-right of the client  
- Click **Connect**  

> ⚠️ Only one person should host **`netalk-server.exe`** at a time.  
> Make sure all users are on the same Hamachi or ZeroTier network.
> Only people with PCs can host.

6. Start chatting!

### macOS:
1. **Download your suitable release.** If you are on a **Mac with Apple Silicon** please install the **`netalk-macos-arm`** package. If you are on a **Mac with an Intel Chip** please intall the **`netalk-macos-intel`** package.
2. Download **Homebrew**.
   The command is:
```
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
```
Once finished, run the command:  ``brew --version``, to see if the installation completed succesfully.

3. Next, install **Wine Stable**. This is the program which will allow us to run .exe files from macOS natively.
   The command is:
```
brew install --cask wine-stable
```
4. If you are on Intel, you can skip this step. For Apple Silicon users, since Macs now use ARM we need another program along with **Wine Stable** to run .exe files. It is called **Rosetta 2**.
   The installation command is:
```
  softwareupdate --install-rosetta --agree-to-license
```
5. You're done! You can now just double click the NetalkClient.exe to run the app.

### Android:
1. Download the **apk file**.
2. Head to downloads or the file manager.
3. Double click on the new apk file.
4. Enjoy!
---

## 🛠️ For Developers

### macOS/Windows:

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

### iOS:
Since I do not have a paid Apple Developer account,

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








