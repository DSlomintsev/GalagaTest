using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;


namespace Actions
{
    public class ActionUtils
    {
        public static IActionData[] JSONToData(string actionsStr)
        {
            //actionsStr = Regex.Replace(actionsStr, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            actionsStr=Regex.Replace(actionsStr, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline).TrimEnd();
            actionsStr = actionsStr.Substring(1, actionsStr.Length - 1);
            var actions = actionsStr.Split('\n');
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action = action.Trim();

                actions[i] = action.Substring(0, action.Length - 1);
            }

            return JSONToData(actions);
        }

        public static IActionData[] JSONToData(string[] actions)
        {
            var len = actions.Length;

            var result = new IActionData[len];

            for (var i = 0; i < len; i++)
            {
                result[i] = ParseAction(actions[i]);
            }

            return result;
        }

        public static IActionData ParseAction(string action)
        {
            if (string.IsNullOrEmpty(action))
            {
                return new NoneActionData
                {
                    type = ActionType.NONE,
                    id = "none"
                };
            }

            var typeArg = "type\": \"";
            var typeArgLen = typeArg.Length;

            var typeStartIndex = action.IndexOf(typeArg) + typeArgLen;
            var typeEndIndex = action.IndexOf("\"", typeStartIndex);
            var type = action.Substring(typeStartIndex, typeEndIndex - typeStartIndex);
            
            IActionData actionData = null;
            switch (type)
            {
                case ActionType.NONE:
                    actionData = JsonConvert.DeserializeObject<NoneActionData>(action);
                    break;
                case ActionType.WAIT:
                    actionData = JsonConvert.DeserializeObject<WaitActionData>(action);
                    break;
                case ActionType.STOP:
                    actionData = JsonConvert.DeserializeObject<StopActionData>(action);
                    break;
                case ActionType.WAIT_TEAM_DESTROYED:
                    actionData = JsonConvert.DeserializeObject<WaitTeamDestroyedActionData>(action);
                    break;
                case ActionType.SPAWN_UNIT:
                    actionData = JsonConvert.DeserializeObject<SpawnUnitActionData>(action);
                    break;
                default:
                    Debug.LogError("Action type " + type + " is not exist");
                    break;
            }

            return actionData;
        }
    }
}