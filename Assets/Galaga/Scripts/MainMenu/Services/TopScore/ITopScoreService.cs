using System.Collections.Generic;

namespace Galaga.MainMenu.Services.TopScore
{
    public interface ITopScoreService
    {
        public void AddScoreItem(string name, float score);
        public void RemoveScoreItem(string name);
        public List<TopScoreItemData> Scores { get; }
    }
}