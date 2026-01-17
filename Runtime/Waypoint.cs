using UnityEngine;

namespace RoachRace.Data
{
    /// <summary>
    /// Data model for a waypoint - represents a point of interest in the world
    /// </summary>
    [System.Serializable]
    public class Waypoint
    {
        /// <summary>
        /// World position of the waypoint
        /// </summary>
        public Vector3 position;

        /// <summary>
        /// Display label for the waypoint
        /// </summary>
        public string label;

        /// <summary>
        /// Icon sprite to display on UI
        /// </summary>
        public Sprite icon;

        public Waypoint(Vector3 position, string label, Sprite icon = null)
        {
            this.position = position;
            this.label = label;
            this.icon = icon;
        }
    }
}
