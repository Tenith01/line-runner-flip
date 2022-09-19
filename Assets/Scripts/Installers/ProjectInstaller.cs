using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISessionUsecase>().To<SessionUsecase>().AsSingle();

        Container.Bind<ISessionPresenter>().To<SessionPresenter>()
            .FromNewComponentOn(gameObject).AsSingle().NonLazy();
        
        
    }
}