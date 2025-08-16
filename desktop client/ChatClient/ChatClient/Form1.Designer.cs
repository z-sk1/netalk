namespace ChatClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtList = new System.Windows.Forms.TextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirmUser = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPrivSend = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrivInput = new System.Windows.Forms.TextBox();
            this.txtPrivUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 135);
            this.label1.TabIndex = 0;
            this.label1.Text = "Netalk";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.txtList);
            this.panel2.Controls.Add(this.btnDisconnect);
            this.panel2.Controls.Add(this.btnConnect);
            this.panel2.Location = new System.Drawing.Point(51, 136);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 457);
            this.panel2.TabIndex = 2;
            // 
            // txtList
            // 
            this.txtList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtList.Location = new System.Drawing.Point(15, 23);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.ReadOnly = true;
            this.txtList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtList.Size = new System.Drawing.Size(172, 241);
            this.txtList.TabIndex = 6;
            this.txtList.Text = "\r\n";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.SystemColors.Info;
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(-14, 288);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(228, 63);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Info;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(-14, 373);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(228, 63);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUser
            // 
            this.txtUser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUser.Location = new System.Drawing.Point(398, 75);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(507, 22);
            this.txtUser.TabIndex = 3;
            this.txtUser.Text = "Guest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(395, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username:";
            // 
            // btnConfirmUser
            // 
            this.btnConfirmUser.Location = new System.Drawing.Point(540, 46);
            this.btnConfirmUser.Name = "btnConfirmUser";
            this.btnConfirmUser.Size = new System.Drawing.Size(79, 23);
            this.btnConfirmUser.TabIndex = 5;
            this.btnConfirmUser.Text = "Confirm";
            this.btnConfirmUser.UseVisualStyleBackColor = true;
            this.btnConfirmUser.Click += new System.EventHandler(this.btnConfirmUser_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.btnPrivSend);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtPrivInput);
            this.panel3.Controls.Add(this.txtPrivUser);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(967, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(211, 458);
            this.panel3.TabIndex = 6;
            // 
            // btnPrivSend
            // 
            this.btnPrivSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrivSend.Location = new System.Drawing.Point(28, 364);
            this.btnPrivSend.Name = "btnPrivSend";
            this.btnPrivSend.Size = new System.Drawing.Size(149, 67);
            this.btnPrivSend.TabIndex = 3;
            this.btnPrivSend.Text = "Send";
            this.btnPrivSend.UseVisualStyleBackColor = true;
            this.btnPrivSend.Click += new System.EventHandler(this.btnPrivSend_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Message:";
            // 
            // txtPrivInput
            // 
            this.txtPrivInput.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtPrivInput.Location = new System.Drawing.Point(11, 288);
            this.txtPrivInput.Multiline = true;
            this.txtPrivInput.Name = "txtPrivInput";
            this.txtPrivInput.Size = new System.Drawing.Size(187, 44);
            this.txtPrivInput.TabIndex = 3;
            this.txtPrivInput.Text = "Type your private message here...";
            this.txtPrivInput.Enter += new System.EventHandler(this.txtPrivInput_Enter);
            this.txtPrivInput.Leave += new System.EventHandler(this.txtPrivInput_Leave);
            // 
            // txtPrivUser
            // 
            this.txtPrivUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtPrivUser.Location = new System.Drawing.Point(11, 165);
            this.txtPrivUser.Multiline = true;
            this.txtPrivUser.Name = "txtPrivUser";
            this.txtPrivUser.Size = new System.Drawing.Size(187, 44);
            this.txtPrivUser.TabIndex = 2;
            this.txtPrivUser.Text = "Type in receiver\'s username here...";
            this.txtPrivUser.Enter += new System.EventHandler(this.txtPrivUser_Enter);
            this.txtPrivUser.Leave += new System.EventHandler(this.txtPrivUser_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Receiver\'s Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 92);
            this.label3.TabIndex = 0;
            this.label3.Text = "Private\r\nMessages\r\n";
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(447, 376);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(149, 67);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtInput
            // 
            this.txtInput.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtInput.Location = new System.Drawing.Point(42, 398);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(388, 22);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "Type in a message\r\n";
            this.txtInput.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            this.txtInput.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(30, 42);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(554, 328);
            this.txtChat.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(-281, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 227);
            this.textBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.txtChat);
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(316, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 457);
            this.panel1.TabIndex = 1;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(927, 75);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(251, 22);
            this.txtIPAddress.TabIndex = 7;
            this.txtIPAddress.Text = "Type in an IP Address (e.g, 192.168.1.1)";
            this.txtIPAddress.Enter += new System.EventHandler(this.txtIPAddress_Enter);
            this.txtIPAddress.Leave += new System.EventHandler(this.txtIPAddress_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.Location = new System.Drawing.Point(957, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 38);
            this.label6.TabIndex = 8;
            this.label6.Text = "IP Address";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1190, 626);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnConfirmUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "   ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirmUser;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrivUser;
        private System.Windows.Forms.Button btnPrivSend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrivInput;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label6;
    }
}

