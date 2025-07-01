using Core;
using GameMechanics.ShootSystem.Base;
using UnityEngine;

namespace AILogic
{
    public class EnemyShoot : MonoBehaviour, IDamage
    {
        [SerializeField] private float damage;
        [SerializeField] private float fireDamage;
        
        public BaseWeapon AttachedWeapon;

        public void FireProjectile()
        {
            AttachedWeapon.Shoot(fireDamage);
        }
        
        public float GetDamageValue()
        {
            return damage;
        }
        
    }
}