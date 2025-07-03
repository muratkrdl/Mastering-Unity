using System;
using ChallengeRewardSystems.Reward;

namespace ChallengeRewardSystems.Challenges
{
    [Serializable]
    public class CommonChallengeData
    {
        public bool isCompleted;
        public RewardType rewardType;
        public int rewardAmount; 
    }
}
