using Core;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private IDamage _enemyDamage;
        private void Start()
        {
            _playerHealth = GetComponent<PlayerHealth>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
            {
                if (collision.gameObject.TryGetComponent(out _enemyDamage))
                {
                    _playerHealth.TakeDamage(_enemyDamage.GetDamageValue());
                }
            }
        }

    }
}