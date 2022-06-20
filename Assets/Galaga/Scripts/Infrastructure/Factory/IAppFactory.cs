using System.Collections.Generic;
using Galaga.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Galaga.Infrastructure.Factory
{
  public interface IAppFactory
  {
    GameObject CreateHud();
    List<ISavedProgressReader> ProgressReaders { get; }
    List<ISavedProgress> ProgressWriters { get; }
    void CleanUp();
  }
}