using System.Collections.Generic;
using Galaga.Game.Actors.Units;


namespace Galaga.Game.Model
{
    public class UnitsModel
    {
        public List<Team> Teams { get; set; } = new ();
    }

    public static class UnitsModelExtensions
    {
        public static Team GetTeam(this UnitsModel model, string teamId)
        {
            var team = model.Teams.Find(x => x.Id == teamId);
            
            if (team == null)
            {
                team = new Team { Id = teamId, Units = new List<UnitController>() };
                model.Teams.Add(team);
            }

            return team;
        }
        
        public static UnitController GetUnit(this UnitsModel model, string unitId)
        {
            UnitController result = null;

            foreach (var team in model.Teams)
            {
                var unit = team.Units.Find(x => x.Id == unitId);
                if (unit != null)
                {
                    result = unit;
                    break;
                }
            }

            return result;
        }
        
        public static void RemoveUnit(this UnitsModel model, string unitId)
        {
            foreach (var team in model.Teams)
            {
                var unit = team.Units.Find(x => x.Id == unitId);
                if (unit != null)
                {
                    team.Units.Remove(unit);
                    break;
                }
            }
        }
    }

    public class Team
    {
        public string Id;
        public List<UnitController> Units { get; set; } = new ();
    }
}