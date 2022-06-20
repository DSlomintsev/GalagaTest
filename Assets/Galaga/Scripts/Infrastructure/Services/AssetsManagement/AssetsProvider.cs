using UnityEngine;

namespace Galaga.Infrastructure.Services.AssetsManagement
{
    public class AssetsProvider : IAssetsProvider
    {
        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
        
        public GameObject Instantiate(string path, Transform container)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, container);
        }

        public T Instantiate<T>(string path) =>
            Instantiate(path).GetComponent<T>();

        public T Instantiate<T>(string path, Vector3 at) =>
            Instantiate(path, at).GetComponent<T>();

        public T Instantiate<T>(string path, Transform container) => 
            Instantiate(path, container).GetComponent<T>();
    }
}