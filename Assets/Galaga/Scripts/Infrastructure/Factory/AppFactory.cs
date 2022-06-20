using System.Collections.Generic;
using Galaga.Infrastructure.Services.AssetsManagement;
using Galaga.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Galaga.Infrastructure.Factory
{
  public class AppFactory : IAppFactory
  {
    private readonly IAssetsProvider _assetsProvider;
    public List<ISavedProgressReader> ProgressReaders { get; } = new ();
    public List<ISavedProgress> ProgressWriters { get; } = new ();

    public AppFactory(IAssetsProvider assetsProvider)
    {
      _assetsProvider = assetsProvider;
    }

    public GameObject CreateHud()
    {
      //TODO: add HUD creation
      return null;
    }

    private void Register(ISavedProgressReader progressReader)
    {
      if (progressReader is ISavedProgress progressWriter)
      {
        ProgressWriters.Add(progressWriter);
      }
      ProgressReaders.Add(progressReader);
    }

    public void CleanUp()
    {
      ProgressReaders.Clear();
      ProgressWriters.Clear();
    }

    private GameObject InstantiateRegistered(string heroPath, Vector3 at)
    {
      GameObject gameObject = _assetsProvider.Instantiate(heroPath, at: at);
      RegisterProgressWatchers(gameObject);
      return gameObject;
    }

    private GameObject InstantiateRegistered(string heroPath)
    {
      GameObject gameObject = _assetsProvider.Instantiate(heroPath);
      RegisterProgressWatchers(gameObject);
      return gameObject;
    }

    private void RegisterProgressWatchers(GameObject gameObject)
    {
      foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
      {
        Register(progressReader);
      }
    }
  }
}