using System;
using System.Collections.Generic;
using UnityEngine;

namespace Galaga.Infrastructure.Config
{
    public class ConfigProviderService
    {
        public List<CashiersConfig> Cashiers;
        public void Load(Action onLoaded = null)
        {
            Cashiers = new List<CashiersConfig>(Resources.LoadAll<CashiersConfig>("Cashiers"));
            
            Debug.Log("Cashiers Config Loaded: " + Cashiers.Count);
            
            onLoaded?.Invoke();
        }

        public CashiersConfig FindCashierById(int id)
        {
            for (var i = 0; i < Cashiers.Count; i++)
            {
                if (id == Cashiers[i].Id)
                {
                    return Cashiers[i];
                }
            }

            return null;
        }
    }
}
