using System;
using PlayFab.ClientModels;

namespace PlayFab.Login
{
    public class EmailLogin : ILogin
    {
        private string _email;
        private string _password;
        
        public EmailLogin(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public void Login(Action<LoginResult> onSuccess, Action<PlayFabError> onFailure)
        {
            var request = new LoginWithEmailAddressRequest()
            {
                Email = _email,
                Password = _password
            };
            PlayFabClientAPI.LoginWithEmailAddress(request, onSuccess, onFailure);
        }
    }
}