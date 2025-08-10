using System;
using PlayFab.ClientModels;

namespace PlayFab.Login
{
    public class DeviceLogin : ILogin
    {
        private readonly string _deviceId;
        
        public DeviceLogin(string deviceId)
        {
            _deviceId = deviceId;
        }
        
        public void Login(Action<LoginResult> onSuccess, Action<PlayFabError> onFailure)
        {
            var request = new LoginWithCustomIDRequest
            {
                CustomId = _deviceId,
                CreateAccount = true // Create account if not exists
            };
            PlayFabClientAPI.LoginWithCustomID(request, onSuccess, onFailure);
        }

    }
}