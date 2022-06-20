using System.Collections.Generic;


namespace Galaga.MainMenu.Services.TopScore
{
    public static class TopScoreServiceUtils
    {
        public static TopScoreItemData GetById(this List<TopScoreItemData> score, string id)
        {
            TopScoreItemData result = default;
            
            for (var i = 0; i < score.Count; i++)
            {
                var item = score[i];
                if (item.Name == id)
                {
                    result = item;
                    break;
                }
            }

            return result;
        }
    }
}