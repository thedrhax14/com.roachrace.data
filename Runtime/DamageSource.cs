using System;
using UnityEngine;

namespace RoachRace.Data
{
    /// <summary>
    /// Contains visual details about who or what caused the damage.
    /// </summary>
    [Serializable]
    public struct DamageSource
    {
        /// <summary>
        /// Name of the entity dealing damage (e.g., "PlayerOne", "Explosive Barrel")
        /// </summary>
        public string AttackerName;

        /// <summary>
        /// URL for the attacker's avatar (Remote PNG or addressable key)
        /// </summary>
        public string AttackerAvatarUrl;

        /// <summary>
        /// The world position where the damage originated from.
        /// </summary>
        public Vector3 SourcePosition;
        public string WeaponIconKey;
    }
}
