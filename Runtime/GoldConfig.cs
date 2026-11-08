using UnityEngine;

namespace Game.Currency
{
    [CreateAssetMenu(menuName = "Game/Currency/Gold Config", fileName = "GoldConfig")]
    public sealed class GoldConfig : ScriptableObject
    {
        [Min(0)] public int StartGold = 0;
    }
}
