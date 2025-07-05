using UnityEngine;

namespace CustomSaveSystem
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Data/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public int SoundVolume;
        public bool IsFullScreen;
        public int GraphicsQuality;
    }
}