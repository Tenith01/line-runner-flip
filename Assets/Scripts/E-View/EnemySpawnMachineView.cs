using System;
using System.Collections;
using System.Collections.Generic;
using A_Entity;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawnMachineView : MonoBehaviour
{
    [SerializeField] 
    private Transform upSpawnPoint;
    [SerializeField] 
    private Transform downSpawnPoint;

    [Inject] private IEnemySpawnMachinePresenter _enemySpawnMachinePresenter;
    
    private void Start()
    {
        StartCoroutine(Fade());
       
    }
    
    IEnumerator Fade()
    {
        while (true)
        {
            if (Random.Range(0,10)%2==1)
            {
                _enemySpawnMachinePresenter.SpawnEnemy(3,downSpawnPoint);
            }
            else
            {
                _enemySpawnMachinePresenter.SpawnEnemy(3,upSpawnPoint);

            }
            yield return new WaitForSeconds(Random.Range(4,8));
        }
    }
}
