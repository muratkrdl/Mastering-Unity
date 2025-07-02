using UnityEngine;

namespace AILogic.StateMachine
{
    public class IdleState : IEnemyState
    {
        private float _idleTime = 3f;
        private float _timer;
        
        public void EnterState(BaseEnemy baseEnemy)
        {
            _timer = 0;
        }

        public void UpdateState(BaseEnemy baseEnemy)
        {
            // Exit Logic
        }

        public void ExitState(BaseEnemy baseEnemy)
        {
            _timer += Time.deltaTime;
            if (_timer >= _idleTime)
            {
                baseEnemy.TransitionToState(baseEnemy.WanderState);
            }
            else if (baseEnemy.PlayerInSight())
            {
                baseEnemy.TransitionToState(baseEnemy.ChaseState);
            }
            else if (baseEnemy.PlayerInRange())
            {
                baseEnemy.TransitionToState(baseEnemy.AttackState);
            }

        }
    }
}