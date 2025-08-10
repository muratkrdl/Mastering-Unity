using GameAnalyticsSDK;
using UnityEngine;

namespace GameAnalytic
{
    public class GameAnalyticsManager : MonoBehaviour
    {
        private void Start()
        {
            GameAnalytics.Initialize();
        }

        public void LevelCompleted(int levelNum)
        {
            Debug.Log("LevelCompleted");
            GameAnalytics.NewDesignEvent("LevelComplete", levelNum);
        }
        
    }
}
