using Zenject;

public class EnemySpawnMachineInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEnemySpawnMachinePresenter>().To<EnemySpawnMachinePresenter>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
    }
}