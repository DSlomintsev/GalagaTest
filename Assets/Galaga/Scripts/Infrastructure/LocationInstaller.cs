using Zenject;


namespace Galaga.Infrastructure
{
    public class LocationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInstallerInterfaces();
            /*Container
                .Bind<IVillagerFactory>()
                .To<VillagerFactory>()
                .AsSingle();*/
        }

        public void BindInstallerInterfaces()
        {
            Container
                .BindInterfacesTo<LocationInstaller>()
                .FromInstance(this)
                .AsSingle();
        }
    }
}