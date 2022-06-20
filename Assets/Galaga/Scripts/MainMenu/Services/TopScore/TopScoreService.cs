using System;
using System.Collections.Generic;
using Zenject;

namespace Galaga.MainMenu.Services.TopScore
{
    public class TopScoreService:ITopScoreService,IInitializable, IDisposable
    {
        private TopScoreModel Model { get; set; }

        public List<TopScoreItemData> Scores => Model.Score;
        
        public void Initialize()
        {
            Model = new TopScoreModel();
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
        }
        
        public void RemoveScoreItem(string name)
        {
            var item = Model.Score.GetById(name);
            Model.Score.Remove(item);
        }
    }
}