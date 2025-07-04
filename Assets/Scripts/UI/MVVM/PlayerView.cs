using UnityEngine;

namespace UI.MVVM
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private PlayerViewModel playerViewModel;
        
        private void Start()
        {
            playerViewModel.UpdatePlayerData(1, 100);
        }

        private void Update()
        {
            Debug.Log("Player Level: " + playerViewModel.PlayerLevel);
            Debug.Log("Player Score: " + playerViewModel.PlayerScore);
        }
    }
}