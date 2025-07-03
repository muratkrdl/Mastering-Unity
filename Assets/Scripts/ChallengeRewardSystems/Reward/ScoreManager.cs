using Extensions;
using UnityEngine;

namespace ChallengeRewardSystems.Reward
{
    public class ScoreManager : Monosingleton<ScoreManager>
    {
        private float _currentScore;
        private int _scoreMultiplier = 1;
        
        public void ApplyMultiplier(int multiplier)
        {
            _scoreMultiplier *= multiplier;
        }
        
        private void ResetMultiplier()
        {
            _scoreMultiplier = 1;
        }
        
        public void AddScore(int scoreValue)
        {
            _currentScore += scoreValue * _scoreMultiplier;
            Debug.Log($"Score: {_currentScore}");
        }

    }
}