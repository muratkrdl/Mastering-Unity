using UnityEngine;

namespace Data_Driven.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public PlayerStats playerStats;
        public float groundDistance;
        
        public Transform groundChecker;
        public LayerMask groundLayer;
        public Rigidbody playerRigidbody;
        
        private bool _isGrounded = true;
        private bool _canDash = true;
        private Vector3 _movementVector;
        
        private void MovePlayer()
        {
            Vector3 movement = new Vector3(_movementVector.x , 0f , _movementVector.y) * playerStats.MoveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }

    }
}