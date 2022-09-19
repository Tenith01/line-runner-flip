using Zenject;

public class EnemySpawnMachineInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEnemySpawnMachineUsecase>().To<EnemySpawnMachineUsecase>().AsSingle();

        Container.Bind<IEnemySpawnMachinePresenter>().To<EnemySpawnMachinePresenter>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
    }
}