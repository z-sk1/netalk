// global variables
let ws = null;
let isConnected = false;
// grab username only when connecting
function connect(txtIP) {
    const username = document.getElementById("userInput").value.trim() || "Guest";
    const serverIP = txtIP.trim();
    if (!serverIP) {
        alert("Please enter a valid IP Address first. e.g(25.9.1.53)");
        return;
    }
    const ipv4Pattern = /^(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}$/;
    if (!ipv4Pattern.test(serverIP)) {
        alert("Please enter a valid IP Address first. e.g(25.9.1.53)");
        return;
    }
    if (!isConnected) {
        try {
            ws = new WebSocket(`ws://${serverIP}:8080/ws`);
            ws.onopen = () => {
                console.log("Connected to server:", serverIP);
                isConnected = true;
                ws.send(username); // send username
                ws.send("/list");  // request user list
            };
            ws.onmessage = (event) => {
                receiveMessage(event.data);
            };
            ws.onerror = (err) => {
                console.error("WebSocket error:", err);
                alert("Connection error");
            };
            ws.onclose = () => {
                console.log("Connection closed");
                isConnected = false;
            };
        } catch (err) {
            alert("Error connecting: " + err.message);
        }
    } else {
        ws.close();
        isConnected = false;
    }
}