using Data;
using UnityEngine;

namespace UI.MVVM
{
    public class PlayerViewModel : MonoBehaviour
    {
        private PlayerData _playerData;
        
        public int PlayerLevel => _playerData.PlayerLevel;
        public int PlayerScore => _playerData.PlayerScore;
        
        private void Start()
        {
            _playerData = new PlayerData();
        }
        
        public void UpdatePlayerData(int level, int score)
        {
            _playerData.PlayerLevel = level;
            _playerData.PlayerScore = score;
        }
    }
}