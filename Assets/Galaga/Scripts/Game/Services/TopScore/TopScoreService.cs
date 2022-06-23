using System;
using System.Collections.Generic;
using Galaga.Common.Utils.Data;
using Galaga.Common.Utils.SaveLoadUtils;
using Zenject;


namespace Galaga.MainMenu.Services.TopScore
{
    public class TopScoreService : ITopScoreService, IInitializable, IDisposable
    {
        private const string ScorePath = "Score";
        private TopScoreModel Model { get; set; }
        public ActiveListData<TopScoreItemData> Score => Model.Score;

        public void Initialize()
        {
            Model = new TopScoreModel();
            LoadScore();
        }

        public void Dispose()
        {
            Model.Score.Clear();
            Model = null;
        }

        public void AddScoreItem(string name, float score)
        {
            var item = new TopScoreItemData { Name = name, Score = score };
            Model.Score.Add(item);

            SaveScore();
        }

        public void RemoveScoreItem(string name)
        {
            var item = Model.Score.GetById(name);
            Model.Score.Remove(item);

            SaveScore();
        }

        public async void SaveScore()
        {
            await SaveLoadJsonPlayerPrefs.SaveAsync(ScorePath, Model.Score.Value);
        }

        public async void LoadScore()
        {
            var loadedScores = await SaveLoadJsonPlayerPrefs.LoadAsync<List<TopScoreItemData>>(ScorePath);
            if (loadedScores != null)
            {
                Model.Score.Value= loadedScores;
            }
        }
    }
}