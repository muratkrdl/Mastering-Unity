using TMPro;
using UI.Abstracts;
using UnityEngine;

namespace UI
{
    public class TopBarView : BaseView
    {
        // FOR EXAMPLE
        [SerializeField] private TextMeshProUGUI _coinText;
        
        private int _coinAmount = 0;
        
        protected override void Start()
        {
            base.Start();
            // StartUIManager.Instance.RegisterView<TopBarView>(this);
            Show();

            UpdateCoinText();
        }

        public void AddCoin(int amount)
        {
            _coinAmount += amount;
            UpdateCoinText();
        }

        private void UpdateCoinText()
        {
            _coinText.text = _coinAmount.ToString();
        }
        
//Add here logic for displaying the currencies for the player

    }
}