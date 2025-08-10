using PlayFab.ClientModels;
using PlayFab.Login;
using UnityEngine;

namespace PlayFab
{
    public class PlayFabManager
    {
        private const string SAVED_EMAIL_KEY = "SavedEmail";
        
        private LoginManager _loginManager;
        private string _userEmail;
        
        private void Start()
        {
            _loginManager = new LoginManager();
            
            if (!PlayerPrefs.HasKey(SAVED_EMAIL_KEY)) return;
            
            string savedEmail = PlayerPrefs.GetString(SAVED_EMAIL_KEY);
            EmailLoginButtonClicked(savedEmail, "SavedPassword");
        }

        public void EmailLoginButtonClicked(string email, string password)
        {
            _userEmail = email;
            _loginManager.SetLoginMethod(new EmailLogin(email, password));
            _loginManager.Login(OnLoginSuccess, OnLoginFailure);
        }

        public void DeviceIDLoginButtonClicked(string deviceID)
        {
            _loginManager.SetLoginMethod(new DeviceLogin(deviceID));
            _loginManager.Login(OnLoginSuccess, OnLoginFailure);
        }
        
        private void OnLoginSuccess(LoginResult result)
        {
            Debug.Log("Login success");
            
            if (!string.IsNullOrEmpty(_userEmail))
                PlayerPrefs.SetString(SAVED_EMAIL_KEY, _userEmail);
            LoadPlayerData(result.PlayFabId);
            
        }
        
        private void OnLoginFailure(PlayFabError error)
        {
            Debug.LogError("Login fail " + error.ErrorMessage);
        }
        
        private void LoadPlayerData(string playFabId)
        {
            var request = new GetUserDataRequest
            {
                PlayFabId = playFabId
            };
            PlayFabClientAPI.GetUserData(request, OnDataSuccess, OnDataFailure);
        }
        
        private void OnDataSuccess(GetUserDataResult result)
        {
            Debug.Log("Player data load success");
        }
        
        private void OnDataFailure(PlayFabError error)
        {
            Debug.LogError("Failed load player data " + error.ErrorMessage);
        }
    }
}