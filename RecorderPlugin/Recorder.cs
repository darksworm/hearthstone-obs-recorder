using OBSWebsocketDotNet;
using System;

namespace RecorderPlugin
{
    internal class Recorder
    {
        public class ConnectionFailedException : Exception { }

        public class AuthorizationFailedException : Exception { }

        OBSWebsocket OBS = new OBSWebsocket();

        private string ConnectionString = String.Empty;
        private string Password = String.Empty;

        public void Connect()
        {
            try
            {
                OBS.Connect(ConnectionString, Password);
            }
            catch (AuthFailureException)
            {
                throw new AuthorizationFailedException();
            }

            if (!OBS.IsConnected)
            {
                throw new ConnectionFailedException();
            }
        }

        public void UpdateSettings(string ip, string port, string password = "")
        {
            ConnectionString = $"ws://{ip}:{port}";
            Password = password;
        }

        internal void StartRecording()
        {
            if (OBS.IsConnected)
            {
                OBS.StartRecording();
            }
        }

        internal void StopRecording()
        {
            if (OBS.IsConnected)
            {
                OBS.StopRecording();
            }
        }

        internal void Unload()
        {
            OBS.Disconnect();
        }
    }
}