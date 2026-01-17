namespace RoachRace.Data
{
    /// <summary>
    /// Interface for game state management commands.
    /// Decoupled from networking - implementations will bridge to network code.
    /// </summary>
    public interface IGameManager
    {
        /// <summary>
        /// Start the game round
        /// </summary>
        void StartGame();

        /// <summary>
        /// Leave the game and return to main menu
        /// </summary>
        void LeaveGame();
    }
}
