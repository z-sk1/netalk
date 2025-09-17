// update chat box
function receiveMessage(msg) {
    let box = null;
    let cleanMsg;
    if (msg.startsWith("/list")) {
        box = document.getElementById("usersBox")
        cleanMsg = msg.replace(/^\/list\s*/, "");
    } else {
        box = document.getElementById("msgsBox")
        cleanMsg = msg;
    }
    document.getElementById(box);
    box.value += cleanMsg + "\n";
    box.scrollTop = box.scrollHeight;
}
// send message
function sendMessage() {
    const input = document.getElementById("chatInput");
    const msg = input.value.trim();
    if (!msg || !ws || ws.readyState !== WebSocket.OPEN) return;
    ws.send(msg);
    input.value = "";
}