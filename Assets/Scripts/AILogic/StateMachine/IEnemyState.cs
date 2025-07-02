using LSP;

namespace AILogic.StateMachine
{
    public interface IEnemyState
    {
        void EnterState(BaseEnemy baseEnemy);
        void UpdateState(BaseEnemy baseEnemy);
        void ExitState(BaseEnemy baseEnemy);
    }
}