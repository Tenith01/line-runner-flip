using Zenject;

public class MainInstaller : MonoInstaller
{
    // ReSharper disable Unity.PerformanceAnalysis
    public override void InstallBindings()
    {
        //Gateway
        Container.BindInterfacesTo<InputGateway>().AsSingle();


        //UseCase
        //Without MonoBehaviours
        Container.Bind<IPlayerUseCase>().To<PlayerUseCase>().AsSingle();
        // Container.Bind<ISessionUsecase>().To<SessionUsecase>().AsSingle().NonLazy();
        // Container.Bind<IPlayerPresenter>().To<PlayerPresenter>().AsSingle();

        //Presenter
        // Container.Bind<IPlayerPresenter>().FromNewComponentOn(gameObject).AsSingle();
        // always need "FromComponentsOn" bind to MonoBehaviour
        Container.Bind<IPlayerPresenter>().To<PlayerPresenter>().FromNewComponentOn(gameObject).AsSingle().NonLazy();


        //View
        //
    }
}