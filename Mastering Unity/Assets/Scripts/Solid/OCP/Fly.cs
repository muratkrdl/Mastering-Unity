using UnityEngine;

namespace SOLID.OCP
{
    public class Fly : BasePowerUp
    {
        public override void ActivatePowerUp()
        {
            Debug.Log("Fly Activate");
        }

        public override void DeactivatePowerUp()
        {
            Debug.Log("Fly Deactivate");
        }
    }
}