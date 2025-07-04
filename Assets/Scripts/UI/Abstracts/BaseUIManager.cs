using System;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace UI.Abstracts
{
    public abstract class BaseUIManager : Monosingleton<BaseUIManager>
    {
        public Dictionary<Type, BaseView> views = new Dictionary<Type, BaseView>();
        private BaseView _lastActiveView;
        
        public void RegisterView<T>(T view) where T : BaseView
        {
            if (view != null && !views.ContainsKey(typeof(T)))
            {
                views.Add(typeof(T), view);
            }
        }

        public void ShowView<T>() where T : BaseView
        {
            if (views.ContainsKey(typeof(T)))
            {
                var view = views[typeof(T)];
                view.Show();
                _lastActiveView = view;
            }
            else
            {
                Debug.LogError("The View Of Type is Not Exist " + typeof(T));
            }
        }
        
        public void HideView<T>()
        {
            if (views.ContainsKey(typeof(T)))
            {
                var view = views[typeof(T)];
                if (view.IsVisible())
                    view.Hide();
            }
        }

        public void HideActiveView()
        {
            if (_lastActiveView != null)
            {
                _lastActiveView.Hide();
                _lastActiveView = null;
            }
        }
        
        public BaseView GetView(Type viewType)
        {
            return views.ContainsKey(viewType) ? views[viewType] : null;
        }
        
        public T GetView<T>()
        {
            if (views.ContainsKey(typeof(T))) 
                return (T)Convert.ChangeType(views[typeof(T)], typeof(T));
            
            return (T)Convert.ChangeType(null, typeof(T));
        }

    }
}
