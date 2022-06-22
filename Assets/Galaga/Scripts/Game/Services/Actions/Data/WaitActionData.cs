using System;

[Serializable]
public struct WaitActionData:IActionData
{
    public string type;
    public string id;

    public float time;
    
    string IActionData.Type => type;
    string IActionData.ID => id;
}