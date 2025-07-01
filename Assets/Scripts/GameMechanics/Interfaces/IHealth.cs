namespace Core
{
    public interface IHealth
    {
        float MaxHealth { get; set; }
        float CurrentHealth { get; set; }
        void TakeDamage(float damage);
        void SetMaxHealth();
        void Heal();
    }
}