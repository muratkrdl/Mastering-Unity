using Extensions;
using UnityEngine;

namespace ChallengeRewardSystems.Reward
{
    public class CurrencyManager : Monosingleton<CurrencyManager>
    {
        private int _currentCoins;
        
        public void AddCoins(int amount)
        {
            _currentCoins += amount;
            Debug.Log($"Coins: {_currentCoins}");
        }
    }
}