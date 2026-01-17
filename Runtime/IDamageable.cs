namespace RoachRace.Data
{
    public interface IDamageable
    {
        void TryConsume(DamageInfo damageInfo);
        bool IsAlive { get; }
        int CurrentHealth { get; }
        int MaxHealth { get; }
    }
}
