using System.Collections;
using Core;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        public static UnityAction onPlayerDied;
        public float startingMaxHealth = 100;
        public float healInterval = 2f;
        public float healAmount = 5f;
        private WaitForSeconds _healIntervalWait;
        private Coroutine _healOverTimeCoroutine;
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
        
        void Start()
        {
            SetMaxHealth();
            _healIntervalWait = new WaitForSeconds(healInterval);
            StartHealingOverTime();
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) onPlayerDied.Invoke();
        }
        
        public void SetMaxHealth()
        {
            MaxHealth = startingMaxHealth;
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
        
        void OnDestroy()
        {
            if (_healOverTimeCoroutine != null)
                StopCoroutine(_healOverTimeCoroutine);
        }

    }
}