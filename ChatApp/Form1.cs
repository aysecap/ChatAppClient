using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private byte[] buffer = new byte[1024];
        private int port = 3000; // Server port
        private Task receiveTask; // Task to handle receiving messages

        public Form1()
        {
            
            InitializeComponent();
            
        }

        // Called when the form is loaded
        private async void Form1_Load(object sender, EventArgs e)
        {
            // Start the connection to the server
            await ConnectToServer();
        }

        // Connect to the server using dynamic IP address resolution
        private async Task ConnectToServer()
        {
            try
            {
                // Get the local machine's host name
                var hostName = Dns.GetHostName();
                // Resolve the host name to an IP address
                IPHostEntry localhost = await Dns.GetHostEntryAsync(hostName);
                IPAddress localIpAddress = localhost.AddressList[0]; // Typically the first address is IPv4

                // Create the TcpClient with the resolved local IP address
                client = new TcpClient();
                await client.ConnectAsync(localIpAddress.ToString(), port); // Use local IP and port

                stream = client.GetStream();
                // Start receiving messages from the server asynchronously
                receiveTask = Task.Run(() => ReceiveMessages());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to server: " + ex.Message);
            }
        }

        // Receive messages from the server asynchronously
        private async Task ReceiveMessages()
        {
            try
            {
                while (client.Connected)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Invoke(new Action(() => DisplayMessage(message))); // Update UI from background thread
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => MessageBox.Show("Error receiving message: " + ex.Message)));
            }
        }

        // Display received message in the chat history
        private void DisplayMessage(string message)
        {
            txtChatHistory.AppendText( message + Environment.NewLine);
        }

        // Send message when the Send button is clicked
        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length); // Send message to server

                    // Display message in chat history
                   // txtChatHistory.AppendText("You: " + message + Environment.NewLine);
                    txtMessage.Clear(); // Clear the input field
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending message: " + ex.Message);
                }
            }
        }

        // Close connection when the form is closed
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null && client.Connected)
            {
                client.Close();
            }
        }
    }
}

