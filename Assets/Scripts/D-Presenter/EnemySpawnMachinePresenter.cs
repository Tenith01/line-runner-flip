using System.Collections;
using System.Collections.Generic;
using A_Entity;
using C_Usecase;
using UnityEngine;
using Zenject;

public interface IEnemySpawnMachinePresenter
{
    void SpawnEnemy(float speed, Transform spawnPosition);
}

public class EnemySpawnMachinePresenter : MonoBehaviour, IEnemySpawnMachinePresenter
{
    [Inject] private IEnemySpawnMachineUsecase _enemySpawnMachineUsecase;
    private float speed;

    [Inject] private EnemyView.Factory _factory;

    public void SpawnEnemy(float speed, Transform spawnPosition)
    {
        var enemyData = new EnemyData(speed, spawnPosition);
        _factory.Create(enemyData);
    }
}