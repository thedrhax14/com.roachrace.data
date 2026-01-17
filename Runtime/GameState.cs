using System;

namespace RoachRace.Data
{
    public enum Status
    {
        Offline,
        Online,
        InGame
    }

    /// <summary>
    /// Current state of the game
    /// </summary>
    [Serializable]
    public enum GameState
    {
        Lobby,
        Starting,
        InProgress,
        GameOver
    }

    /// <summary>
    /// Player statistics during a game round
    /// </summary>
    [Serializable]
    public class PlayerStats
    {
        public int networkId;
        public string playerName;
        public Team team;
        public Status status;
        public int respawnsLeft;
        public int deaths;
        public bool reachedEnd;
        public float survivalTime;
        public long ping;
        public bool isSpeaking;
        public float Amplitude;

        public PlayerStats()
        {
        }

        public PlayerStats(int networkId, string playerName, Team team, int maxRespawns)
        {
            this.networkId = networkId;
            this.playerName = playerName;
            this.team = team;
            this.respawnsLeft = maxRespawns;
            this.deaths = 0;
            this.reachedEnd = false;
            this.survivalTime = 0f;
            this.isSpeaking = false;
        }
        
        public PlayerStats SetStatus(Status status)
        {
            this.status = status;
            return this;
        }

        public PlayerStats SetPlayerName(string name)
        {
            playerName = name;
            return this;
        }

        public PlayerStats SetIsSpeaking(bool speaking)
        {
            isSpeaking = speaking;
            if(speaking) status = Status.Online;
            return this;
        }

        public PlayerStats SetAmplitude(float amplitude)
        {
            Amplitude = amplitude;
            return this;
        }

        override public string ToString()
        {
            return $"PlayerStats(networkId={networkId}, playerName={playerName}, team={team}, respawnsLeft={respawnsLeft}, deaths={deaths}, reachedEnd={reachedEnd}, survivalTime={survivalTime}, isSpeaking={isSpeaking}, Amplitude={Amplitude})";
        }

        public string ToVoiceChatLog()
        {
            return $"PlayerStats(networkId={networkId}, playerName={playerName}, isSpeaking={isSpeaking}, Amplitude={Amplitude})";
        }

        public PlayerStats SetPing(long ping)
        {
            this.ping = ping;
            return this;
        }
    }

    /// <summary>
    /// Final game results with all player statistics
    /// </summary>
    [Serializable]
    public class GameResult
    {
        public PlayerStats[] playerStats;
        public bool survivorsWon;
        public float totalGameTime;

        public GameResult()
        {
            playerStats = new PlayerStats[0];
        }

        public GameResult(PlayerStats[] playerStats, bool survivorsWon, float totalGameTime)
        {
            this.playerStats = playerStats;
            this.survivorsWon = survivorsWon;
            this.totalGameTime = totalGameTime;
        }
    }
}
