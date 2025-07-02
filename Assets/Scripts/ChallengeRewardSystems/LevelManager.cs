using System.Collections.Generic;
using ChallengeRewardSystems.Challenges;
using Extensions;
using UnityEngine;

namespace ChallengeRewardSystems
{
    public class LevelManager : Monosingleton<LevelManager>
    {
        public Dictionary<int, ChallengeType> levelChallengeMapping = new Dictionary<int, ChallengeType>();
        public int _currentLevel;
        
        private void Start()
        {
            StartChallengeForCurrentLevel(_currentLevel);
        }
        
        public void StartChallengeForCurrentLevel(int currentLevel)
        {
            if (levelChallengeMapping.TryGetValue(currentLevel, out ChallengeType challengeType))
            {
                ChallengeManager.Instance.StartChallenge(challengeType);
            }
            else
            {
                Debug.LogError($"No challenge mapped for Level {currentLevel}");
            }
        }

    }
}