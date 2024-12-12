namespace ChatApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtMessage;
        private Button btnSend;
        private TextBox txtChatHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtMessage = new TextBox();
            btnSend = new Button();
            txtChatHistory = new TextBox();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 438);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(308, 35);
            txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(335, 438);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(111, 43);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtChatHistory
            // 
            txtChatHistory.Location = new Point(12, 23);
            txtChatHistory.Multiline = true;
            txtChatHistory.Name = "txtChatHistory";
            txtChatHistory.ReadOnly = true;
            txtChatHistory.ScrollBars = ScrollBars.Vertical;
            txtChatHistory.Size = new Size(434, 399);
            txtChatHistory.TabIndex = 2;
            // 
            // Form1
            // 
            AcceptButton = btnSend;
            ClientSize = new Size(508, 510);
            Controls.Add(txtChatHistory);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TCP Chat Client";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}