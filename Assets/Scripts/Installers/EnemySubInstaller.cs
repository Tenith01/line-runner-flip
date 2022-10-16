using A_Entity;
using UnityEngine;
using Zenject;


public class EnemySubInstaller : MonoInstaller
{
    [Inject] private EnemyData _enemyData;
    
    [SerializeField] private EnemyView _enemyView;

    public override void InstallBindings()
    {
        Container.BindInstance(_enemyData);
        Container.BindInstance(_enemyView);
    }
}