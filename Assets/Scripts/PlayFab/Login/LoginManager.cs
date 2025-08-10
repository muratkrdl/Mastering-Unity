using System;
using PlayFab.ClientModels;
using UnityEngine;

namespace PlayFab.Login
{
    public class LoginManager
    {
        private ILogin _loginMethod;
        
        public void SetLoginMethod(ILogin method)
        {
            _loginMethod = method;
        }
        
        public void Login(Action<LoginResult> onSuccess, Action<PlayFabError> onFailure)
        {
            if (_loginMethod != null)
            {
                _loginMethod.Login(onSuccess , onFailure);
            }
            else
            {
                Debug.LogError("No login method");
            }
        }
    }
}