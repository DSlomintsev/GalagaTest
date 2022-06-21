using Galaga.Common.Utils.Data;


namespace Galaga.MainMenu.Services.TopScore
{
    public class TopScoreModel
    {
        public ActiveListData<TopScoreItemData> Score { get; set; } = new();
    }
}