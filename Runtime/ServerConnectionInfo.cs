using System;

namespace RoachRace.Data
{
    /// <summary>
    /// Connection information for a game server
    /// </summary>
    [Serializable]
    public class ServerConnectionInfo
    {
        public string ip;
        public int port;

        public ServerConnectionInfo()
        {
        }

        public ServerConnectionInfo(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        /// <summary>
        /// Check if connection info is valid (non-empty IP and valid port)
        /// </summary>
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(ip) && port > 0 && port <= 65535;
        }

        public override string ToString()
        {
            return $"{ip}:{port}";
        }
    }
}
