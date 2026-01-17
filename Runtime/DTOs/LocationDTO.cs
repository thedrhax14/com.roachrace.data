using System;

namespace RoachRace.Data.DTOs
{
    /// <summary>
    /// Data Transfer Object for Edgegap API location response
    /// Maps directly to the JSON structure from the API
    /// </summary>
    [Serializable]
    public class LocationDTO
    {
        public string city;
        public string continent;
        public string country;
        public string timezone;
        public string administrative_division;
        public string latitude;
        public string longitude;
        public string type;
        public TagDTO[] tags;

        /// <summary>
        /// Convert DTO to domain model
        /// </summary>
        public Location ToModel(int numberOfPlayers = 0, float latency = 0f)
        {
            return new Location
            {
                id = $"{continent}-{city}-{administrative_division}",
                continent = continent,
                country = country,
                city = city,
                numberOfPlayers = numberOfPlayers,
                latency = latency
            };
        }
    }

    [Serializable]
    public class TagDTO
    {
        public string key;
        public string value;
    }

    [Serializable]
    public class LocationsResponseDTO
    {
        public LocationDTO[] locations;
        public string[] messages;
    }
}
