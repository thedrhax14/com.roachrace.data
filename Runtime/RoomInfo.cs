using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RoachRace.Data
{
    /// <summary>
    /// Information about a game room/lobby
    /// </summary>
    [Serializable]
    public class RoomInfo
    {
        public string roomName;
        public List<Player> players;
        public bool isRoomOwner;

        public RoomInfo()
        {
            players = new List<Player>();
        }

        public RoomInfo(string roomName)
        {
            this.roomName = roomName;
            this.players = new List<Player>();
        }

        public RoomInfo(string roomName, List<Player> players)
        {
            this.roomName = roomName;
            this.players = players ?? new List<Player>();
        }

        /// <summary>
        /// Get player count
        /// </summary>
        public int GetPlayerCount()
        {
            return players != null ? players.Count : 0;
        }

        /// <summary>
        /// Add a player to the room
        /// </summary>
        public void AddPlayer(Player player)
        {
            if (players == null)
                players = new List<Player>();
            
            players.Add(player);
            UnityEngine.Debug.Log($"[RoomInfo] Player '{player.playerName}' added to room '{roomName}'. Total players: {GetPlayerCount()}");
        }

        /// <summary>
        /// Remove a player by network ID
        /// </summary>
        public bool RemovePlayerByNetworkId(int networkId)
        {
            if (players == null)
                return false;

            for (int i = players.Count - 1; i >= 0; i--)
            {
                if (players[i].networkPlayer != null && players[i].networkPlayer.NetworkId == networkId)
                {
                    players.RemoveAt(i);
                    UnityEngine.Debug.Log($"[RoomInfo] Player with Network ID '{networkId}' removed from room '{roomName}'. Total players: {GetPlayerCount()}");
                    return true;
                }
            }
            UnityEngine.Debug.LogWarning($"[RoomInfo] Player with Network ID '{networkId}' not found in room '{roomName}'. No players removed.");
            return false;
        }

        /// <summary>
        /// Find player by network ID
        /// </summary>
        public Player FindPlayerByNetworkId(int networkId)
        {
            if (players == null)
                return null;

            foreach (var player in players)
            {
                if (player.networkPlayer != null && player.networkPlayer.NetworkId == networkId)
                    return player;
            }

            return null;
        }

        /// <summary>
        /// Get all players on a specific team
        /// </summary>
        public List<Player> GetPlayersByTeam(Team team)
        {
            if (players == null)
                return new List<Player>();

            List<Player> teamPlayers = new List<Player>();
            foreach (var player in players)
            {
                if (player.team == team)
                    teamPlayers.Add(player);
            }

            return teamPlayers;
        }

        /// <summary>
        /// Clear all players from the room
        /// </summary>
        public void ClearPlayers()
        {
            if (players != null)
                players.Clear();
        }
        
        public override string ToString()
        {
            return $"RoomInfo(Name: {roomName}, Players: {GetPlayerCount()}, IsOwner: {isRoomOwner})";
        }
    }
}
