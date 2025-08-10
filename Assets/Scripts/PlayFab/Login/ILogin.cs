using System;
using PlayFab.ClientModels;

namespace PlayFab.Login
{
    public interface ILogin
    {
        void Login(Action<LoginResult> onSuccess, Action<PlayFabError> onFailure);
    }
}
