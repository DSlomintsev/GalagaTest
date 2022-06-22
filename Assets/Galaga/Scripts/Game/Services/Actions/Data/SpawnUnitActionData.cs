using System;
using Galaga.Game.Commands.Data;


[Serializable]
public struct SpawnUnitActionData:IActionData
{
    public string type;
    public string id;

    public SpawnUnitData Data;
    
    string IActionData.Type => type;
    string IActionData.ID => id;
}