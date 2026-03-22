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
        /// ClientId of the instigator (real user), or -1 for environment/unknown.
        /// </summary>
        public int InstigatorId;
        public DamageSource Source;
    }
}