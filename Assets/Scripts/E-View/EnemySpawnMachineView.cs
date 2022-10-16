using System;
using System.Collections;
using System.Collections.Generic;
using A_Entity;
using UnityEngine;
using Zenject;

public class EnemySpawnMachineView : MonoBehaviour
{
    [SerializeField] 
    private Transform upSpawnPoint;
    [SerializeField] 
    private Transform downSpawnPoint;

    [Inject] private IEnemySpawnMachinePresenter _enemySpawnMachinePresenter;

    [Inject] private EnemyView.Factory _factory;
    private void Start()
    {
        // _enemySpawnMachinePresenter.SpawnEnemy(enemy[0],upSpawnPoint);
        var enemyData = new EnemyData(3, upSpawnPoint);
        _factory.Create(enemyData);
    }
}
