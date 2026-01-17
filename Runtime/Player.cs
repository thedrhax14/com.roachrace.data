using System;

namespace RoachRace.Data
{
    /// <summary>
    /// Team types in the game
    /// </summary>
    [Serializable]
    public enum Team
    {
        Ghost,
        Survivor
    }

    /// <summary>
    /// Player information in a room
    /// </summary>
    [Serializable]
    public class Player
    {
        public string playerName;
        public string imageUrl;
        public Team team;
        public INetworkPlayer networkPlayer;

        public Player()
        {
        }

        public Player(string playerName, string imageUrl, Team team, INetworkPlayer networkPlayer = null)
        {
            this.playerName = playerName;
            this.imageUrl = imageUrl;
            this.team = team;
            this.networkPlayer = networkPlayer;
        }
    }

    /// <summary>
    /// Interface for network player interaction.
    /// Decoupled from FishNet - implementations will bridge to network code.
    /// </summary>
    public interface INetworkPlayer
    {
        /// <summary>
        /// Unique identifier for this network player
        /// </summary>
        int NetworkId { get; }

        /// <summary>
        /// Whether this player is the local client
        /// </summary>
        bool IsLocalPlayer { get; }

        /// <summary>
        /// Whether this player is the server/host
        /// </summary>
        bool IsServer { get; }

        /// <summary>
        /// Update player's team
        /// </summary>
        void SetTeam(Team team);

        /// <summary>
        /// Toggle player's team between Ghost and Survivor
        /// </summary>
        void ToggleTeam();

        /// <summary>
        /// Update player's name
        /// </summary>
        void SetPlayerName(string name);

        /// <summary>
        /// Update player's image URL
        /// </summary>
        void SetImageUrl(string url);

        /// <summary>
        /// Kick this player from the room (server only)
        /// </summary>
        void Kick();

        /// <summary>
        /// Get current latency/ping to this player
        /// </summary>
        int GetPing();
    }
}
