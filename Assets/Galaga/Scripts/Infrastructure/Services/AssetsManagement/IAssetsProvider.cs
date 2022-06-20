using UnityEngine;

namespace Galaga.Infrastructure.Services.AssetsManagement
{
  public interface IAssetsProvider
  {
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Vector3 at);
    T Instantiate<T>(string path);
    T Instantiate<T>(string path, Vector3 at);
    T Instantiate<T>(string path, Transform container);
  }
}