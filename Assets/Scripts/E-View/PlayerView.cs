using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour
{
    [Inject] private ISessionPresenter _sessionPresenter;
    [Inject] private IPlayerPresenter playerPresenter;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject inGameUICanvas;

    public MMFeedbacks flipFeedback;
    public MMFeedbacks hitFeedback;

    private float _timeTresh;

    private void Start()
    {
        playerPresenter.moveInputStream.Subscribe(RotatePlayer);
        this.OnTriggerEnter2DAsObservable().Subscribe(collider => AddScore(collider)).AddTo(this);
    }

    private void RotatePlayer(float rotateValue)
    {
        // Debug.Log("timeTrash: " + _timeTresh);
        // Debug.Log("time: " + Time.time);

        if (rotateValue > 0)
        {
            if (Time.time > _timeTresh && !transform.position.Equals((-4.04f, 0.8f, 0f)))
            {
                flipFeedback.PlayFeedbacks();
            }

            transform.position = new Vector3(-4.04f, 0.8f, 0f);
        }
        else
        {
            if (Time.time > _timeTresh && !transform.position.Equals((-4.04f, -0.8f, 0f)))
            {
                flipFeedback.PlayFeedbacks();
            }

            transform.position = new Vector3(-4.04f, -0.8f, 0f);
        }

        _timeTresh = Time.time + 0.1f;
    }


    private void AddScore(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("AddScore"))
        {
            _sessionPresenter.AddScore(1);
        }
        else if (collider2D.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Fade());

        }
    }

    IEnumerator Fade()
    {
        hitFeedback.PlayFeedbacks();
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        inGameUICanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        
    }

}