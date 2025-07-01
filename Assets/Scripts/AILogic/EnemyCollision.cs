using System;
using Core;
using UnityEngine;

namespace AILogic
{
    public class EnemyCollision : MonoBehaviour
    {
        private IDamage _playerDamage;
        private EnemyHealth _enemyHealth;

        private void Start()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("PlayerProjectile"))
            {
                if (other.gameObject.TryGetComponent(out _playerDamage))
                {
                    _enemyHealth.TakeDamage(_playerDamage.GetDamageValue());
                }
            }
        }
        
    }
}