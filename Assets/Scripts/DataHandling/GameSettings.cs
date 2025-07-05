using UnityEngine;

namespace DataHandling
{
    [CreateAssetMenu(fileName = "New GameSettings", menuName = "SO/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public int PlayerHealth;
        public int EnemyCount;
        public float PlayerSpeed;
    }
}
