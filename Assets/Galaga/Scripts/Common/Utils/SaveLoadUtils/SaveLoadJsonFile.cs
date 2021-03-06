using System.IO;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace Galaga.Common.Utils.SaveLoadUtils
{
    public static class SaveLoadJsonFile
    {
        public static async UniTask<T> LoadAsync<T>(string path)
        {
            using var streamReader = new StreamReader(Path.Combine(Application.dataPath, $"{path}{FileFormats.JsonFormat}"));
            var str = await streamReader.ReadToEndAsync();
            var item = JsonConvert.DeserializeObject<T>(str);
            streamReader.Close();
            streamReader.Dispose();
            return item;
        }
        
        public static async UniTask SaveAsync(string path, object data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            await using var streamWriter = new StreamWriter(Path.Combine(Application.dataPath, $"{path}{FileFormats.JsonFormat}"));
            await streamWriter.WriteLineAsync(json);
            streamWriter.Close();
            await streamWriter.DisposeAsync();
        }
    }
}