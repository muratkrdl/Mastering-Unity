using System.Collections;
using ChallengeRewardSystems.Reward;
using UnityEngine;

namespace ChallengeRewardSystems.Challenges
{
    public class EnemyWavesChallenge : BaseChallenge
    {
        public int totalWaves = 5;
        private int _currentWave = 0;
        
        public override void StartChallenge()
        {
            if (!commonChallengeData.isCompleted)
            {
                StartCoroutine(StartEnemyWavesChallenge());
            }
            else
            {
                Debug.Log("Challenge already completed!");
            }
        }
        
        IEnumerator StartEnemyWavesChallenge()
        {
            while (_currentWave < totalWaves)
            {
                yield return StartCoroutine(SpawnEnemyWave());
                _currentWave++;
            }
            CompleteChallenge();
        }
        
        public override void CompleteChallenge()
        {
            if (!commonChallengeData.isCompleted)
            {
                RewardManager.Instance.GrantReward(commonChallengeData);
                commonChallengeData.isCompleted = true;
            }
            else
            {
                Debug.Log("Challenge already completed!");
            }
        }
        
        IEnumerator SpawnEnemyWave()
        {
            Debug.Log($"Spawning Wave {_currentWave + 1}");
            yield return new WaitForSeconds(2f);
        }

    }
}