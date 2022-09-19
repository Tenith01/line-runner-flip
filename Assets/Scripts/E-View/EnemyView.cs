using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] 
    private float speed;
    void Start()
    {
        this.UpdateAsObservable().Subscribe(_ => MoveToLeft()).AddTo(this);
    }

    private void MoveToLeft()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left) ;
    }
}
