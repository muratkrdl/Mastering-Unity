using UnityEngine;

namespace AILogic.StateMachine
{
    public class AttackState : IEnemyState
    {
        private float attackTimer;
        private float timeBetweenAttacks = 1.5f;
        
        public void EnterState(BaseEnemy baseEnemy)
        {
            baseEnemy.animationsComponent.StartAttackAnimations();
            attackTimer = 0f;
        }
        public void UpdateState(BaseEnemy baseEnemy)
        {
            LookAtPlayer(baseEnemy);
            attackTimer += Time.deltaTime;
            if (attackTimer >= timeBetweenAttacks)
            {
                AttackPlayer(baseEnemy);
                attackTimer = 0f;
            }
        }
        public void ExitState(BaseEnemy baseEnemy)
        {
            baseEnemy.animationsComponent.StopAttackAnimations();
        }
        
        private void LookAtPlayer(BaseEnemy baseEnemy)
        {
            /* baseEnemy.transform.LookAt(baseEnemy.Player); */
            
            Vector3 lookDirection = baseEnemy.Player.position - baseEnemy.transform.position;
            lookDirection.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            baseEnemy.transform.rotation = Quaternion.Slerp(baseEnemy.transform.rotation,
                rotation, Time.deltaTime * baseEnemy.rotationSpeed);
        }
        
        private void AttackPlayer(BaseEnemy baseEnemy)
        {
            baseEnemy.shootComponent.FireProjectile();
        }
    }
}