using UnityEngine;

namespace SOLID.OCP
{
    public class DoubleJump : BasePowerUp
    {
        public override void ActivatePowerUp()
        {
            Debug.Log("Double Jump Activate");
        }

        public override void DeactivatePowerUp()
        {
            Debug.Log("Double Jump Deactivate");
        }
    }
}