namespace Game.Currency
{
    public sealed class GoldCurrency : CurrencyBase, IGoldCurrency
    {
        public GoldCurrency(GoldConfig config, GoldCurrencyId id)
            : base(id)
        {
            if (config == null)
            {
                return;
            }

            if (config.StartGold > 0)
            {
                SetValue(config.StartGold);
            }
        }

        public void Add(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            SetValue(Current.Value + amount);
        }
    }
}