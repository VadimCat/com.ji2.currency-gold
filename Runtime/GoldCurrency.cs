using UnityEngine;

namespace Game.Currency
{
    public sealed class GoldCurrency : CurrencyBase, IGoldCurrency
    {
        public const string PlayerPrefsKey = "Currency.Gold.Current";

        public GoldCurrency(GoldConfig config, GoldCurrencyId id)
            : base(id)
        {
            int startGold = config == null ? 0 : Mathf.Max(0, config.StartGold);
            SetValue(Mathf.Max(0, PlayerPrefs.GetInt(PlayerPrefsKey, startGold)));
        }

        public void Add(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            SetAndSave(Current.Value + amount);
        }

        public bool TrySpend(int amount)
        {
            if (amount <= 0 || Current.Value < amount)
            {
                return false;
            }

            SetAndSave(Current.Value - amount);
            return true;
        }

        private void SetAndSave(int value)
        {
            int safeValue = Mathf.Max(0, value);
            SetValue(safeValue);
            PlayerPrefs.SetInt(PlayerPrefsKey, safeValue);
            PlayerPrefs.Save();
        }
    }
}
