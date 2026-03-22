using UnityEngine;
using System;

namespace RoachRace.Data
{
    /// <summary>
    /// Payload describing a single application of damage.<br/>
    /// <br/>
    /// Typical usage:<br/>
    /// - Created on the server when applying damage to <c>NetworkHealth</c>.<br/>
    /// - Forwarded to observers and/or broadcast into the death log, using <see cref="DamageSource.WeaponIconKey"/> for user-facing attribution.
    /// </summary>
    [Serializable]
    public struct DamageInfo
    {
        public int Amount;
        public Vector3 Point;
        public Vector3 Normal;
        /// <summary>
        /// ClientId of the instigator (real user), or -1 for environment/unknown.
        /// </summary>
        public int InstigatorId;
        public DamageSource Source;
    }
}