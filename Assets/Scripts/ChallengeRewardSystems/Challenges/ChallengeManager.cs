using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace ChallengeRewardSystems.Challenges
{
    public class ChallengeManager : Monosingleton<ChallengeManager>
    {
        public Dictionary<ChallengeType, BaseChallenge> ChallengeDictionary = new Dictionary<ChallengeType, BaseChallenge>();
        
        private BaseChallenge _currentChallenge;
        
        public void StartChallenge(ChallengeType challengeType)
        {
            if (ChallengeDictionary.TryGetValue(challengeType, out BaseChallenge challengeScript))
            {
                if (!challengeScript.commonChallengeData.isCompleted)
                {
                    SetCurrentChallenge(challengeScript);
                    _currentChallenge.StartChallenge();
                }
                else
                {
                    Debug.Log("Challenge already completed!");
                }
            }
            else
            {
                Debug.LogError($"No challenge script found for ChallengeType{challengeType}");
            }
        }
        
        private void SetCurrentChallenge(BaseChallenge challengeScript)
        {
            if (_currentChallenge != null)
            {
                _currentChallenge.CompleteChallenge();
            }
            _currentChallenge = challengeScript;
        }

    }
}