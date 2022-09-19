using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour
{
    [Inject] private ISessionPresenter _sessionPresenter;
    [Inject] private IPlayerPresenter playerPresenter;

    private void Start()
    {
        playerPresenter.moveInputStream.Subscribe(RotatePlayer);
        this.OnTriggerEnter2DAsObservable().Subscribe(collider => AddScore(collider)).AddTo(this);
        ;
    }

    private void RotatePlayer(float rotateValue)
    {
        if (rotateValue > 0)
        {
            transform.position = new Vector3(-4.04f, 0.8f, 0f);
        }
        else
        {
            transform.position = new Vector3(-4.04f, -0.8f, 0f);
        }
    }

    private void AddScore(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("AddScore"))
        {
            _sessionPresenter.AddScore(1);
        }
        else if (collider2D.gameObject.CompareTag("Enemy"))
        {
        }
    }
}