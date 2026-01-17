using System;
using Newtonsoft.Json;

namespace RoachRace.Data.DTOs
{
    /// <summary>
    /// Data Transfer Object for Edgegap deployment creation request
    /// </summary>
    [Serializable]
    public class DeploymentRequestDTO
    {
        public string application;
        public string version;
        public bool require_cached_locations;
        public UserDTO[] users;
        public EnvironmentVariableDTO[] environment_variables;
        public string[] tags;
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public WebhookDTO webhook_on_ready;
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public WebhookDTO webhook_on_error;
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public WebhookDTO webhook_on_terminated;
    }

    [Serializable]
    public class UserDTO
    {
        public string user_type; // "ip_address" or "geo_coordinates"
        public UserDataDTO user_data;
    }

    [Serializable]
    public class UserDataDTO
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ip_address;
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? latitude;
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? longitude;
    }

    [Serializable]
    public class EnvironmentVariableDTO
    {
        public string key;
        public string value;
        public bool is_hidden;
    }

    [Serializable]
    public class WebhookDTO
    {
        public string url;
    }

    [Serializable]
    public class DeploymentResponseDTO
    {
        public string request_id;
    }

    [Serializable]
    public class DeploymentStatusDTO
    {
        public string request_id;
        public string fqdn;
        public string app_name;
        public string app_version;
        public string current_status;
        public bool running;
        public bool whitelisting_active;
        public string start_time;
        public string removal_time;
        public int? elapsed_time;
        public string last_status;
        public bool error;
        public string error_detail;
        public System.Collections.Generic.Dictionary<string, PortInfoDTO> ports;
        public string public_ip;
        public SessionDTO[] sessions;
        public LocationInfoDTO location;
        public string[] tags;
        public string sockets;
        public string sockets_usage;
        public string command;
        public string arguments;
        public int max_duration;
    }

    [Serializable]
    public class SessionDTO
    {
        public string session_id;
        public string status;
        public bool ready;
        public bool linked;
        public string kind;
        public string user_count;
    }

    [Serializable]
    public class LocationInfoDTO
    {
        public string city;
        public string country;
        public string continent;
        public string administrative_division;
        public string timezone;
        public float latitude;
        public float longitude;
    }
}
