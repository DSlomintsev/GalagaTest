using System;
using Galaga.Infrastructure.Config;


namespace Galaga.Data
{
    [Serializable]
    public class PlayerProgress
    {
        private readonly ConfigProviderService _configProviderService;
        
        //public List<CashiersData> Cashiers = new List<CashiersData>();
    
        public float MainBudget;
        public float BudgetPerSecond;

        //TODO: Add data for save/load
        public PlayerProgress(ConfigProviderService configProviderService)
        {
            _configProviderService = configProviderService;
            MainBudget = 1f;
            BudgetPerSecond = 1f;
        }
        
        public void CreateFirstCashier()
        {
            //Cashiers.Add(new CashiersData(_configProviderService.FindCashierById(0)));
        }
        
        public override string ToString()
        {
            return $" PlayerProgress: ";
        }
    }
}