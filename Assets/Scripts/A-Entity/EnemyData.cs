using UnityEngine;

namespace A_Entity
{
    public class EnemyData
    {
        public readonly float enemySpeed;
        public readonly Transform enemyPosition;

        public EnemyData(float enemySpeed, Transform enemyPosition)
        {
            this.enemySpeed = enemySpeed;
            this.enemyPosition = enemyPosition;
        }
    }
}