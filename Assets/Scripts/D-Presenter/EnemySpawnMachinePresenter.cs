using System.Collections;
using System.Collections.Generic;
using C_Usecase;
using UnityEngine;
using Zenject;

public interface IEnemySpawnMachinePresenter
{
    void SpawnEnemy(GameObject enemy,Transform spawnPosition);
}

public class EnemySpawnMachinePresenter : MonoBehaviour, IEnemySpawnMachinePresenter
{
    [Inject] private IEnemySpawnMachineUsecase _enemySpawnMachineUsecase;
    private float speed;
    
    public void SpawnEnemy(GameObject enemy, Transform spawnPosition)
    {
        var newEnemy = Instantiate(enemy, spawnPosition.position, Quaternion.identity);
        newEnemy.GetComponent<EnemyView>().speed = 3;
    }
}
