using GameMechanics.Input;
using GameMechanics.ShootSystem.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace GameMechanics.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        public static UnityAction onFire;
        
        [SerializeField] BaseWeapon currentWeapon;
        [SerializeField] private float fireDamage;
        [SerializeField] private float shootingInterval = 0.5f;
        
        private float _timeSinceLastShot = 0f;
        
        private void Update()
        {
            _timeSinceLastShot += Time.deltaTime;
        }
        private void OnEnable()
        {
            PlayerInputEvents.Instance.onShoot += OnShootFire;
        }
        private void OnDisable()
        {
            PlayerInputEvents.Instance.onShoot -= OnShootFire;
        }
        private void OnShootFire()
        {
            if (_timeSinceLastShot >= shootingInterval)
            {
                currentWeapon.Shoot(fireDamage);
                _timeSinceLastShot = 0f;
                onFire.Invoke();
            }
        }

    }
}