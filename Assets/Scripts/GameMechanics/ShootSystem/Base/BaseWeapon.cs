using ObjectPool;
using UnityEngine;

namespace GameMechanics.ShootSystem.Base
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        [SerializeField] protected BaseProjectile attachedProjectile;
        [SerializeField] protected float weaponPower;
        [SerializeField] protected Transform muzzleTransform;
        [SerializeField] protected float projectileForce;

        public virtual void Shoot(float fireDamage)
        {
            GameObject projectileObject = ObjectPoolManager.Instance.GetPooledObject(attachedProjectile.tag);
            if (projectileObject != null)
            {
                projectileObject.transform.position = muzzleTransform.position;
                if (projectileObject.TryGetComponent<Rigidbody>(out var rb))
                {
                    rb.AddForce(muzzleTransform.forward * projectileForce, ForceMode.Impulse);
                    float modifiedDamage = fireDamage + weaponPower;
                    attachedProjectile.SetDamageValue(modifiedDamage);
                }
            }

        }
    }
}