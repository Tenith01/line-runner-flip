using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemySpawnMachinePresenter
{
    void SpawnEnemy(GameObject enemy,Transform spawnPosition);
}

public class EnemySpawnMachinePresenter : MonoBehaviour, IEnemySpawnMachinePresenter
{
    private float speed;
    
    public void SpawnEnemy(GameObject enemy, Transform spawnPosition)
    {
        var newEnemy = Instantiate(enemy, spawnPosition.position, Quaternion.identity);
        newEnemy.GetComponent<EnemyView>().speed = 3;
    }
}
