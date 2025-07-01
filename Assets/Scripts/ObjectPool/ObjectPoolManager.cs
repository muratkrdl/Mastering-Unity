using Extensions;
using UnityEngine;

namespace ObjectPool
{
    // TODO : Hey MURAT! { Implement real ObjectPoolSystem }
    public class ObjectPoolManager : Monosingleton<ObjectPoolManager>
    {
        [SerializeField] private GameObject normalProjectilePrefab;
        
        public GameObject GetPooledObject(string attachedProjectileTag)
        {
            if (normalProjectilePrefab.CompareTag(attachedProjectileTag))
            {
                return Instantiate(normalProjectilePrefab);
            }

            return null;
        }
    }
}