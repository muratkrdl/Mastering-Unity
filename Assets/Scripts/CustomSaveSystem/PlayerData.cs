using UnityEngine;

namespace CustomSaveSystem
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data")]
    public class PlayerData : ScriptableObject
    {
        public string PlayerName;
        public int PlayerLevel;
        public float PlayerExperience;
    }
}
