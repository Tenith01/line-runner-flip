using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    
    public float speed;
    void Start()
    {
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
}
