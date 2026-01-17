namespace RoachRace.Data
{
    public enum DamageType
    {
        Contact,
        Projectile,
        Explosion,
        Environment,
        Impact,      // Physics-based impact damage (HL2 style)
        Crush        // Continuous crushing damage (HL2 style)
    }
}
