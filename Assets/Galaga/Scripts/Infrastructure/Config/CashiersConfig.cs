using UnityEngine;

namespace Galaga.Infrastructure.Config
{
    [CreateAssetMenu(fileName = "CashierData", menuName = "Cashier")]
    public class CashiersConfig : ScriptableObject
    {
        public string Name; //ui
        public string AboutCashier; // ui
        public int Id;
        public int PriceCashier;
        public float CoefPriceUpgrading;
        public float CoefCountClientPerMinute;
    }
}
