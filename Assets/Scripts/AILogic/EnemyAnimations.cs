using System;
using UnityEngine;

namespace AILogic
{
    public class EnemyAnimations : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartAttackAnimations()
        {
            _animator.SetBool("IsAttacking", true);
        }
        
        public void StopAttackAnimations()
        {
            _animator.SetBool("IsAttacking", false);
        }
        
    }
}