using System;

namespace RoachRace.Data
{
    /// <summary>
    /// Lightweight payload for a "kill feed" / death log UI.
    /// 
    /// Notes:
    /// - Team is stored as an int to allow an "unknown" (-1) value.
    ///   0 = Ghost, 1 = Survivor (matches <see cref="Team"/> enum ordering).
    /// </summary>
    [Serializable]
    public struct DeathLogEntry
    {
        public DeathLogActor Attacker;
        public DeathLogActor Victim;

        /// <summary>
        /// Optional key used by UI to select a weapon icon (or display a label).
        /// </summary>
        public string WeaponIconKey;

        /// <summary>
        /// Damage type (fallback if WeaponIconKey is empty).
        /// </summary>
        public DamageType DamageType;

        /// <summary>
        /// Optional server tick when this entry was produced.
        /// </summary>
        public uint ServerTick;
    }

    [Serializable]
    public struct DeathLogActor
    {
        public string Name;
        public string AvatarUrl;

        /// <summary>
        /// -1 = unknown, otherwise see <see cref="Team"/> ordering.
        /// </summary>
        public int TeamId;
    }
}
