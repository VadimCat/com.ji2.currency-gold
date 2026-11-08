using Game.Currency;
using TMPro;
using UnityEngine;
using VContainer;

public sealed class GoldCurrencyView : MonoBehaviour
{
    [SerializeField] private TMP_Text amountText;

    private IGoldCurrency _currency;

    [Inject]
    public void Construct(IGoldCurrency currency)
    {
        _currency = currency;
        _currency.Current.ValueChanged += HandleChanged;
        UpdateText(_currency.Current.Value);
    }

    private void OnDestroy()
    {
        _currency.Current.ValueChanged -= HandleChanged;
    }

    private void HandleChanged(int value)
    {
        UpdateText(value);
    }

    private void UpdateText(int value)
    {
        amountText.text = value.ToString();
    }
}
