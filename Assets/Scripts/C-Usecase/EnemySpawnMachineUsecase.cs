using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace C_Usecase
{
    public interface IEnemySpawnMachineUsecase
    {
        void SpawnEnemy(float speed,Transform upSpawnPoint,Transform downSpawnPoint);
    }

    public class EnemySpawnMachineUsecase : IEnemySpawnMachineUsecase
    {
        public void SpawnEnemy(float speed, Transform upSpawnPoint, Transform downSpawnPoint)
        {
        }
    }
}