using System;
using System.Collections;
using System.Collections.Generic;
using A_Entity;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class EnemyView : MonoBehaviour
{
    [Inject] private EnemyData _circleData;
    public float speed;
    void Start()
    {
        speed = _circleData.enemySpeed;
        var spawnPostion = _circleData.enemyPosition;
        transform.Translate(spawnPostion.position); 
        this.UpdateAsObservable().Subscribe(_ => MoveToLeft()).AddTo(this);
    }

    private void MoveToLeft()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left) ;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("DestroyPoint"))
        {
            Destroy(gameObject);
        }
    }
    
    public class Factory : PlaceholderFactory<EnemyData, EnemyView>
    {
    }
}
