using System;

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
