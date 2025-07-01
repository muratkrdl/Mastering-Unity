using Core;
using UnityEngine;

namespace GameMechanics.ShootSystem.Base
{
    public abstract class BaseProjectile : MonoBehaviour, IDamage
    {
        private float _damage;

        public virtual void SetDamageValue(float value)
        {
            _damage = value;
        }
        
        public float GetDamageValue()
        {
            return _damage;
        }
        
    }
}
