using Galaga.Infrastructure.Loading;
using UnityEngine;
using Zenject;


namespace Galaga.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        [Inject] public AppStateMachine AppStateMachine { get; set; }
        [Inject] public SceneLoader SceneLoader { get; set; }
        [Inject] public LoadingSceneAnim LoadingSceneAnim { get; set; }
        [Inject] public DiContainer DiContainer { get; set; }


        public void Enter(string sceneName)
        {
            LoadingSceneAnim.Show();
            SceneLoader.Load(sceneName, onLoaded: HandleSceneLoaded);
        }

        public void Exit()
        {
            LoadingSceneAnim.Hide();
        }

        private void HandleSceneLoaded()
        {
            DiContainer = FindSceneContext();
            InitGameWorld();
            AppStateMachine.Enter<AppLoopState>();
        }

        private void InitGameWorld()
        {
            InitServices();
            InitStore();
        }

        private void InitServices()
        {
            //_diContainer.Resolve<BudgetCoroutineStarter>().Init();
        }

        private void InitStore()
        {
            /*var storeCollectionProvider = _diContainer.Resolve<StoreCollectionProvider>();
            storeCollectionProvider.Init();

            var processingUIManager = _diContainer.Resolve<ProcessingUIManager>();
            foreach (Department department in storeCollectionProvider.Departments)
            {
                processingUIManager.AddDepartment(department);
            }

            var villagerFactory = _diContainer.Resolve<IVillagerFactory>();
            foreach (VillagerSpawner spawner in storeCollectionProvider.Spawners)
            {
                spawner.Init((VillagerFactory)villagerFactory, storeCollectionProvider);
            }
            var vehicleFactory = _diContainer.Resolve<IVehicleFactory>();
            var vehicleSpawner = _diContainer.Resolve<VehicleSpawner>();
            vehicleSpawner.Init((VehicleFactory)vehicleFactory, storeCollectionProvider);*/
        }

        private static DiContainer FindSceneContext() => 
            Object.FindObjectOfType<SceneContext>().Container;
    }
}