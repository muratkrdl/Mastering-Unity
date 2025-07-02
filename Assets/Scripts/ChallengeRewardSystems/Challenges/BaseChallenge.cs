using UnityEngine;

namespace ChallengeRewardSystems.Challenges
{
    public abstract class BaseChallenge : MonoBehaviour
    {
        public CommonChallengeData commonChallengeData;
        public abstract void StartChallenge();
        public abstract void CompleteChallenge();
    }
}