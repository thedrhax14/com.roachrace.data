using UnityEngine;
using System;

namespace RoachRace.Data
{
    [Serializable]
    public struct DamageInfo
    {
        public int Amount;
        public DamageType Type;
        public Vector3 Point;
        public Vector3 Normal;
        /// <summary>
        /// NetworkObjectId of the attacker
        /// </summary>
        public int InstigatorId;
        public DamageSource Source;
    }
}