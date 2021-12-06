using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace RecorderPlugin
{
    public partial class SettingsDialog : Form
    {
        internal class IPInvalidException : Exception { }
        internal class PortInvalidException : Exception { }

        public class SettingsChangedEvent : EventArgs
        {
            public readonly string IPAddress;
            public readonly string Port;
            public readonly string Password;

            public SettingsChangedEvent(string IPAddress, string Port, string Password)
            {
                this.IPAddress = IPAddress;
                this.Port = Port;
                this.Password = Password;
            }
        }

        public SettingsDialog(string ip, string port, string password)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;

            ipAddrBox.Text = ip;
            portBox.Text = port;
            passwordBox.Text = password;
        }

        public event EventHandler<SettingsChangedEvent> SettingsChanged;

        private string GetIPAddress()
        {
            if (ipAddrBox.Text == String.Empty || !IPAddress.TryParse(ipAddrBox.Text, out _))
            {
                ipAddrBox.ForeColor = Color.Red;
                throw new IPInvalidException();
            }

            ipAddrBox.ForeColor = Color.Black;
            return ipAddrBox.Text;
        }

        private string GetPort()
        {
            if (portBox.Text == String.Empty || !int.TryParse(portBox.Text, out _))
            {
                portBox.ForeColor = Color.Red;
                throw new PortInvalidException();
            }

            portBox.ForeColor = Color.Black;
            return portBox.Text;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsChanged?.Invoke(this, new SettingsChangedEvent(GetIPAddress(), GetPort(), passwordBox.Text));
            }
            catch (PortInvalidException)
            {
                return;
            }
            catch (IPInvalidException)
            {
                return;
            }
        }

        private void ipAddrLabel_Click(object sender, EventArgs e)
        {
            ipAddrBox.Focus();
        }

        private void portLabel_Click(object sender, EventArgs e)
        {
            portBox.Focus();
        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {
            passwordBox.Focus();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DestroyHandle();
        }
    }
}
