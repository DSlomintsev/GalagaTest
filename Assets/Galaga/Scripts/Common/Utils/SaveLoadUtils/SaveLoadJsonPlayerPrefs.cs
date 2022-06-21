using System.IO;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace Galaga.Common.Utils.SaveLoadUtils
{
    public static class SaveLoadJsonPlayerPrefs
    {
        public static async UniTask<T> LoadAsync<T>(string path)
        {
            var str = PlayerPrefs.GetString($"{path}{FileFormats.JsonFormat}","");
            var item = JsonConvert.DeserializeObject<T>(str);
            return item;
        }
        
        public static async UniTask SaveAsync(string path, object data)
        {
            var str = JsonConvert.SerializeObject(data, Formatting.Indented);
            PlayerPrefs.SetString($"{path}{FileFormats.JsonFormat}",str);
        }
    }
}