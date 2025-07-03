using ChallengeRewardSystems.Challenges;
using Extensions;
using UnityEngine;

namespace ChallengeRewardSystems.Reward
{
    public class RewardManager : Monosingleton<RewardManager>
    {
        public void GrantReward(CommonChallengeData commonData)
        {
            switch (commonData.rewardType)
            {
                case RewardType.PowerUp:
                    break;
                case RewardType.UnlockableWeapon:
                    break;
                case RewardType.ScoreMultiplier:
                    ApplyScoreMultiplier(commonData.rewardAmount);
                    break;
                case RewardType.SecretArea:
                    break;
                case RewardType.Coins:
                    GrantCoins(commonData.rewardAmount);
                    break;
            }
        }
        
        private void ApplyScoreMultiplier(int multiplier)
        {
            ScoreManager.Instance.ApplyMultiplier(multiplier);
            Debug.Log($"Score Multiplier Applied: {multiplier}x");
        }
        
        private void GrantCoins(int coinAmount)
        {
            CurrencyManager.Instance.AddCoins(coinAmount);
            Debug.Log($"Coins Granted: {coinAmount}");
        }
        
    }
}