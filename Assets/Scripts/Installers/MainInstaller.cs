using A_Entity;
using C_Usecase;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    // ReSharper disable Unity.PerformanceAnalysis
    
    [SerializeField]
    private GameObject enemyPrefab;
    public override void InstallBindings()
    {
        //Gateway
        Container.BindInterfacesTo<InputGateway>().AsSingle();


        //UseCase
        //Without MonoBehaviours
        Container.Bind<IPlayerUseCase>().To<PlayerUseCase>().AsSingle();
        Container.Bind<IEnemySpawnMachineUsecase>().To<EnemySpawnMachineUsecase>().AsSingle();
        // Container.Bind<ISessionUsecase>().To<SessionUsecase>().AsSingle().NonLazy();
        // Container.Bind<IPlayerPresenter>().To<PlayerPresenter>().AsSingle();

        //Presenter
        // Container.Bind<IPlayerPresenter>().FromNewComponentOn(gameObject).AsSingle();
        // always need "FromComponentsOn" bind to MonoBehaviour
        Container.Bind<IPlayerPresenter>().To<PlayerPresenter>().FromNewComponentOn(gameObject).AsSingle().NonLazy();


        //Enemy Installer
        Container.BindFactory<EnemyData, EnemyView, EnemyView.Factory>()
            .FromSubContainerResolve()
            .ByNewContextPrefab<EnemySubInstaller>(enemyPrefab)
            .AsSingle();
        
    }
}