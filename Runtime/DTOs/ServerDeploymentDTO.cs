using System;
using System.Collections.Generic;

namespace RoachRace.Data.DTOs
{
    /// <summary>
    /// Data Transfer Object for Edgegap API deployment response
    /// Maps directly to the JSON structure from the API
    /// </summary>
    [Serializable]
    public class ServerDeploymentDTO
    {
        public string request_id;
        public string fqdn;
        public string start_time;
        public bool ready;
        public string public_ip;
        public Dictionary<string, PortInfoDTO> ports;
        public string[] tags;
        public string sockets;
        public string sockets_usage;
        public bool is_joinable_by_session;

        /// <summary>
        /// Convert DTO to domain model
        /// </summary>
        public ServerDeployment ToModel()
        {
            int udpPort = 0;
            string serverName = fqdn ?? request_id;
            int playerCount = 0;

            // Extract UDP port
            if (ports != null)
            {
                foreach (var port in ports)
                {
                    if (port.Value.protocol.ToUpper() == "UDP")
                    {
                        udpPort = port.Value.external;
                        break;
                    }
                }
            }

            // Parse player count from sockets_usage if available
            if (!string.IsNullOrEmpty(sockets_usage) && int.TryParse(sockets_usage, out int count))
            {
                playerCount = count;
            }

            return new ServerDeployment
            {
                request_id = request_id,
                server_name = serverName,
                created_by = "Unknown", // Not provided by API, can be set separately
                number_of_players = playerCount,
                public_ip = public_ip,
                udp_port = udpPort
            };
        }
    }

    [Serializable]
    public class PortInfoDTO
    {
        public int external;
        public int @internal;
        public string protocol;
        public string name;
        public bool tls_upgrade;
        public string link;
        public int? proxy;
    }

    [Serializable]
    public class PaginationInfoDTO
    {
        public int number;
        public int? next_page_number;
        public int? previous_page_number;
        public PaginatorInfoDTO paginator;
        public bool has_next;
        public bool has_previous;
    }

    [Serializable]
    public class PaginatorInfoDTO
    {
        public int num_pages;
    }

    [Serializable]
    public class DeploymentsResponseDTO
    {
        public ServerDeploymentDTO[] data;
        public int total_count;
        public PaginationInfoDTO pagination;
        public string[] message;
    }
}
