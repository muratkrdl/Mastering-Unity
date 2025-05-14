using System;
using UnityEngine;

namespace SOLID.OCP
{
    public class PowerUpManager : MonoBehaviour
    {
        private DoubleJump _doubleJump;
        private Fly _fly;
        
        private void Start()
        {
            _doubleJump = new DoubleJump();
            _fly = new Fly();
            
            
            
            
            ActivatePowerUp(_doubleJump);
            DeactivatePowerUp(_doubleJump);
        }
        
        private void ActivatePowerUp(BasePowerUp powerUp)
        {
            powerUp.ActivatePowerUp();
        }
        
        private void DeactivatePowerUp(BasePowerUp powerUp)
        {
            powerUp.DeactivatePowerUp();
        }
        
    }
}