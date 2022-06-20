using System.Collections;
using UnityEngine;

namespace Galaga.Infrastructure.Services.CoroutineRunner
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator routine);
  }
}