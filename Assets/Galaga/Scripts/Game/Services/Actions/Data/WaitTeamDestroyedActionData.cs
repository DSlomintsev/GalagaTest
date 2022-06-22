using System;

[Serializable]
public struct WaitTeamDestroyedActionData:IActionData
{
    public string type;
    public string id;
    public string teamId;

    string IActionData.Type => type;
    string IActionData.ID => id;
}