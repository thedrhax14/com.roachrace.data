using System;
using UnityEngine;

namespace RoachRace.Data
{
    /// <summary>
    /// Lightweight DTO published when damage is applied, intended for UI visualization
    /// (floating damage numbers, kill feed hooks, etc).
    /// </summary>
    [Serializable]
    public struct DamageEventData
    {
        public DamageInfo DamageInfo;
        public string VictimName;
        public Vector3 DamagePosition;
        public bool IsFatal;
        public int VictimRemainingHealth;
        public float EventTime;
    }
}
