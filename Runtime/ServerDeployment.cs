using System;

namespace RoachRace.Data
{
    [Serializable]
    public class ServerDeployment
    {
        public string request_id;
        public string server_name;
        public string created_by;
        public int number_of_players;
        public string public_ip;
        public int udp_port;

        public string GetDisplayName()
        {
            return $"{request_id} - {public_ip}";
        }

        public ServerConnectionInfo GetConnectionInfo()
        {
            return new ServerConnectionInfo(public_ip, udp_port);
        }
    }
}
