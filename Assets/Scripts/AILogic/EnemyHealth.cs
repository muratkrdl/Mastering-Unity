using System.Collections;
using Core;
using UnityEngine;
using UnityEngine.Events;

namespace AILogic
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float startMaxHealth = 100;
        [SerializeField] private float healAmount = 5f;
        [SerializeField] private float healInterval = 2f;
        
        private float _maxHealth;
        private float _currentHealth;

        private WaitForSeconds _healIntervalWait;
        private Coroutine _healOverTimeCoroutine;

        public UnityAction onEnemyDied;

        public float MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
                if (_currentHealth <= 0)
                {
                    onEnemyDied?.Invoke();
                }
            }
        }

        private void Start()
        {
            _maxHealth = startMaxHealth;
            _healIntervalWait = new WaitForSeconds(healInterval);
            StartHealingOverTime();
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
        }

        public void SetMaxHealth()
        {
            CurrentHealth = MaxHealth;
        }

        public void Heal()
        {
            CurrentHealth += healAmount;
            CurrentHealth = Mathf.Min(CurrentHealth, MaxHealth);
        }
        
        private void StartHealingOverTime()
        {
            _healOverTimeCoroutine = StartCoroutine(HealOverTime());
        }
        private IEnumerator HealOverTime()
        {
            while (true)
            {
                yield return _healIntervalWait;
                Heal();
            }
        }

        
    }
}