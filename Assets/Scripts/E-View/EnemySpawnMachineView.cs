using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnMachineView : MonoBehaviour
{
    [SerializeField] 
    private Transform upSpawnPoint;
    [SerializeField] 
    private Transform downSpawnPoint;

    [SerializeField] 
    private GameObject[] enemy;
    
    [Inject] private IEnemySpawnMachinePresenter _enemySpawnMachinePresenter;

    private void Start()
    {
        _enemySpawnMachinePresenter.SpawnEnemy(enemy[0],upSpawnPoint);
    }
}
