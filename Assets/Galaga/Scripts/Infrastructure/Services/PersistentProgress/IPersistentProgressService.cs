using Galaga.Data;


namespace Galaga.Infrastructure.Services.PersistentProgress
{
  public interface IPersistentProgressService
  {
    PlayerProgress Progress { get; set; }
  }
}