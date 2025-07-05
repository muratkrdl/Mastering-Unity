using UnityEngine;

namespace DataHandling
{
    public class SettingsManager : MonoBehaviour
    {
        public GameSettings gameSettings;
       
        public void SaveSettings() {
            string jsonSettings = JsonUtility.ToJson(gameSettings);
            System.IO.File.WriteAllText(Application.persistentDataPath +
                                        "/settings.json", jsonSettings);
        }

        public void LoadSettings() {
            if (System.IO.File.Exists(Application.persistentDataPath + "/settings.json"))
            {
                string jsonSettings = System.IO.File.ReadAllText
                    (Application.persistentDataPath + "/settings.json");
                gameSettings = JsonUtility.FromJson<GameSettings>(jsonSettings);
            }
        }

    }
}
