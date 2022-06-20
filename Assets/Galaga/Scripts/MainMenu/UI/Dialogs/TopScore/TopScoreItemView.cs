using Galaga.MainMenu.Services.TopScore;
using TMPro;
using UnityEngine;

namespace Galaga.MainMenu.UI.Dialogs.TopScore
{
    public class TopScoreItemView:MonoBehaviour
    {
        [SerializeField] private TMP_Text item;

        public void SetData(TopScoreItemData data)
        {
            item.text = data.Name + ";" + data.Score;
        }
    }
}
