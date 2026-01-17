namespace RoachRace.Data
{
    /// <summary>
    /// Interface for network room management (no FishNet dependencies)
    /// </summary>
    public interface INetworkRoom
    {
        /// <summary>
        /// Start the game (host only)
        /// </summary>
        void StartGame();

        /// <summary>
        /// Leave the current room
        /// </summary>
        void LeaveRoom();

        /// <summary>
        /// Get the room name
        /// </summary>
        string RoomName { get; }
    }
}
