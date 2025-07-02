using System;
using AILogic.StateMachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace AILogic
{
    [RequireComponent(typeof(EnemyHealth), typeof(EnemyAnimations), typeof(EnemyShoot))]
    public abstract class BaseEnemy : MonoBehaviour
    {
        [HideInInspector] public NavMeshAgent NavMeshAgent;
        public Transform Player;

        protected IEnemyState CurrentState;
        public IEnemyState WanderState;
        public IEnemyState IdleState;
        public IEnemyState AttackState;
        public IEnemyState ChaseState;
        public IEnemyState DeathState;

        public float attackRange = 5f;
        [SerializeField] public float chaseSpeed;
        [SerializeField] public float rotationSpeed;

        [FormerlySerializedAs("animationComponent")] public EnemyAnimations animationsComponent;
        public EnemyShoot shootComponent;
        public EnemyHealth healthComponent;

        protected void Start()
        {
            WanderState = new WanderState();
            IdleState = new IdleState();
            AttackState = new AttackState();
            ChaseState = new ChaseState();
            DeathState = new DeathState();
            
            CurrentState = WanderState;

            Player = GameObject.FindGameObjectWithTag("Player").transform;
            NavMeshAgent = GetComponent<NavMeshAgent>();
            animationsComponent = GetComponent<EnemyAnimations>();
            shootComponent = GetComponent<EnemyShoot>();
            healthComponent = GetComponent<EnemyHealth>();
            healthComponent.onEnemyDied += OnDied;
        }

        protected virtual void Update()
        {
            CurrentState.UpdateState(this);
        }
        
        public bool IsIdleConditionMet()
        {
            return !PlayerInSight() && !PlayerInRange();
        }
        
        public bool PlayerInSight()
        {
            Vector3 directionToPlayer = Player.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;
            Ray ray = new Ray(transform.position, directionToPlayer.normalized);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distanceToPlayer))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool PlayerInRange()
        {
            Vector3 directionToPlayer = Player.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;
            if (distanceToPlayer <= attackRange)
            {
                float angleToPlayer = Vector3.Angle(transform.forward,
                    directionToPlayer.normalized);
                float attackConeAngle = 45f;
                if (angleToPlayer <= attackConeAngle * 0.5f)
                {
                    return true;
                }
            }

            return false;
        }

        public void TransitionToState(IEnemyState newState)
        {
            CurrentState?.ExitState(this);
            CurrentState = newState;
            CurrentState?.EnterState(this);
        }
        private void OnDied()
        {
            healthComponent.onEnemyDied -= OnDied;
            TransitionToState(DeathState);
        }
        
    }
}