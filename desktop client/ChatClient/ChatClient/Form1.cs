using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient client;
        NetworkStream stream;

        bool isConnected = false;

        System.Windows.Forms.Timer listRefreshTimer;
        private void Form1_Load(object sender, EventArgs e)
        {
            txtInput.Text = "Type your message here...";
            txtInput.ForeColor = Color.Gray;

            txtPrivInput.ForeColor = Color.Gray;

            txtUser.ForeColor = Color.Gray;

            txtPrivUser.ForeColor = Color.Gray;

            txtIPAddress.ForeColor = Color.Gray;

            btnDisconnect.Enabled = false;
            btnConfirmUser.Enabled = false;
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            if (txtInput.Text == "Type your message here..." && txtInput.ForeColor == Color.Gray)
            {
                txtInput.ForeColor = Color.Black;
                txtInput.Text = "";
            }
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                txtInput.Text = "Type your message here...";
                txtInput.ForeColor = Color.Gray;
            }
        }
        private void txtPrivInput_Enter(object sender, EventArgs e)
        {
            if (txtPrivInput.Text == "Type your private message here..." && txtPrivInput.ForeColor == Color.Gray)
            {
                txtPrivInput.ForeColor = Color.Black;
                txtPrivInput.Text = "";
            }
        }

        private void txtPrivInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrivInput.Text))
            {
                txtPrivInput.Text = "Type your private message here...";
                txtPrivInput.ForeColor = Color.Gray;
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Guest" && txtUser.ForeColor == Color.Gray)
            {
                txtUser.ForeColor = Color.Black;
                txtUser.Text = "";
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                txtUser.Text = "Guest";
                txtUser.ForeColor = Color.Gray;
            }
        }

        private void txtPrivUser_Enter(object sender, EventArgs e)
        {
            if (txtPrivUser.Text == "Type in receiver's username here..." && txtPrivUser.ForeColor == Color.Gray)
            {
                txtPrivUser.ForeColor = Color.Black;
                txtPrivUser.Text = "";
            }
        }

        private void txtPrivUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrivUser.Text))
            {
                txtPrivUser.Text = "Type in receiver's username here...";
                txtPrivUser.ForeColor = Color.Gray;
            }
        }

        private void txtIPAddress_Enter(object sender, EventArgs e)
        {
            if (txtIPAddress.Text == "Type in an IP Address (e.g, 192.168.1.1)" && txtIPAddress.ForeColor == Color.Gray)
            {
                txtIPAddress.ForeColor = Color.Black;
                txtIPAddress.Text = "";
            }
        }

        private void txtIPAddress_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIPAddress.Text))
            {
                txtIPAddress.Text = "Type in an IP Address (e.g, 192.168.1.1)";
                txtIPAddress.ForeColor = Color.Gray;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void btnPrivSend_Click(object sender, EventArgs e)
        {
            SendPrivMessage();
        }

        private void SendMessage()
        {
            string msg = txtInput.Text.Trim();
            if (!string.IsNullOrEmpty(msg) && msg != "Type your message here..." && isConnected)
            {
                byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
                stream.Write(data, 0, data.Length);
                txtInput.Text = "";
            }
        }

        private void SendPrivMessage()
        {
            string name = txtPrivUser.Text.Trim();
            string msg = txtPrivInput.Text.Trim();
            
            if (!string.IsNullOrEmpty(name) && name != "Type in receiver's username here..." && !string.IsNullOrEmpty(msg) && msg != "Type your private message here..." && isConnected)
            {
                string whisperCmd = "/whisper";
                byte[] data = Encoding.UTF8.GetBytes(whisperCmd + " " + name + " " + msg + "\n");
                stream.Write(data, 0, data.Length);
                txtPrivInput.Text = "";
                txtPrivUser.Text = "";
            }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

        private void AppendMessage(TextBox a, string msg)
        {
            if (a.InvokeRequired)
            {
                a.Invoke(new MethodInvoker(() => AppendMessage(a, msg)));
            }
            else
            {
                a.AppendText(msg + Environment.NewLine);
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Handle multiple messages in the same buffer
                    string[] messages = msg.Split('\n');
                    foreach (string m in messages)
                    {
                        string trimmed = m.Trim();
                        if (trimmed.StartsWith("/list"))
                        {
                            string listContent = trimmed.Substring(5).Trim();
                            AppendMessage(txtList, listContent);
                        }
                        else if (!string.IsNullOrEmpty(trimmed))
                        {
                            AppendMessage(txtChat, trimmed);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               AppendMessage(txtChat, "Disconnected: " + ex.Message);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIPAddress.Text == "Type in an IP Address (e.g, 192.168.1.1)" && txtIPAddress.ForeColor == Color.Gray || string.IsNullOrEmpty(txtIPAddress.Text))
                {
                    MessageBox.Show("Please enter a valid IP address.");
                    return;
                }

                string serverIP = txtIPAddress.Text.Trim();

                client = new TcpClient(serverIP, 12345);
                stream = client.GetStream();
                isConnected = true;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;

                // Send username
                string username = txtUser.Text.Trim();
                if (string.IsNullOrEmpty(username) || username == "Guest")
                {
                    username = "Guest";
                }
                byte[] nameData = Encoding.UTF8.GetBytes(username + "\n");
                stream.Write(nameData, 0, nameData.Length);

                btnConfirmUser.Enabled = true;

                // Receive threads

                Thread receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                // List refresh timer
                listRefreshTimer = new System.Windows.Forms.Timer();
                listRefreshTimer.Interval = 1500;
                listRefreshTimer.Tick += ListRefreshTimer_Tick;
                listRefreshTimer.Start();

                // List all online users
                string listCmd = "/list";
                byte[] listData = Encoding.UTF8.GetBytes(listCmd + "\n");
                stream.Write(listData, 0, listData.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to server: " + ex.Message);
                isConnected = false;
            }
        }

        private void ListRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (isConnected && stream != null)
            {
                // Clear the current list
                txtList.Clear();

                byte[] listData = Encoding.UTF8.GetBytes("/list\n");
                stream.Write(listData, 0, listData.Length);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                try
                {
                    client?.Close();
                    stream?.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not disconnect from server: " + ex.Message);
                }
                finally
                {
                    isConnected = false;
                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    listRefreshTimer.Stop();
                }
            }
        }

        private string currentUsername = "";
        private void btnConfirmUser_Click(object sender, EventArgs e)
        {
            if (!isConnected) return;

            string newUsername = txtUser.Text.Trim();

            if (!string.IsNullOrEmpty(newUsername) && newUsername != currentUsername)
            {
                string renameCmd = "/rename:" + newUsername;
                byte[] renameData = Encoding.UTF8.GetBytes(renameCmd + "\n");
                stream.Write(renameData, 0, renameData.Length);
                currentUsername = newUsername;
                AppendMessage(txtChat, "You are now known as " + currentUsername);
            }
        }
    }
}