using Galaga.Common.Utils.Data;


namespace Galaga.MainMenu.Services.TopScore
{
    public interface ITopScoreService
    {
        public void AddScoreItem(string name, float score);
        public void RemoveScoreItem(string name);
        public void SaveScore();
        public void LoadScore();
        public ActiveListData<TopScoreItemData> Score { get; }
    }
}