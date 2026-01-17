using System;

namespace RoachRace.Data
{
    [Serializable]
    public class Location
    {
        public string id;
        public string continent;
        public string country;
        public string city;
        public int numberOfPlayers;
        public float latency;

        public override string ToString()
        {
            return $"{continent}-{city} ({numberOfPlayers} players, {latency}ms)";
        }

        public string GetDisplayName()
        {
            return $"{GetContinentAbbreviation()}-{city} #{id}";
        }

        string GetContinentAbbreviation()
        {
            if (string.IsNullOrEmpty(continent))
                return "";

            var words = continent.Split(' ');
            string abbreviation = "";
            
            foreach (var word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    abbreviation += word[0];
                }
            }

            return abbreviation.ToUpper();
        }
    }
}
