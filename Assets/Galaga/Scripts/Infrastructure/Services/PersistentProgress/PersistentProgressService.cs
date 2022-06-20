using Galaga.Data;

namespace Galaga.Infrastructure.Services.PersistentProgress
{
  public class PersistentProgressService : IPersistentProgressService
  {
    public PlayerProgress Progress { get; set; }
  }
}