using DG.Tweening;
using UnityEngine;

namespace UI.Abstracts
{
    public abstract class BaseView : MonoBehaviour
    {
        // Dotween for animations
        public Tween tweenComponent;
        public bool isActiveView;
        
        private Canvas canvas;
        
        protected virtual void Start()
        {
            canvas = GetComponent<Canvas>();
        }

        public virtual void Show()
        {
            isActiveView = true;
            canvas.enabled = true;
            gameObject.SetActive(true);
            PlayTweens(true);
            ShowView();
        }
        
        public virtual void ShowView()
        {
            PlayTweens(true);
        }

        public virtual void Hide()
        {
            PlayTweens(false);
        }
        
        private void OnOutTweenComplete()
        {
            isActiveView = false;
            canvas.enabled = false;
        }
        
        public virtual void HideCanvas()
        {
            canvas.enabled = false;
        }

        public bool IsVisible()
        {
            return canvas.enabled;
        }
        
        private void PlayTweens(bool state)
        {
            if (state)
            {
                // open anim
                // tweenComponent.Play();
            }
            else
            {
                // close anim
                // tweenComponent.Close();
            }
        }
        
    }
}