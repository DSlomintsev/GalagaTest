using System;

[Serializable]
public struct StopActionData:IActionData
{
    public string type;
    public string id;

    string IActionData.Type => type;
    string IActionData.ID => id;
}