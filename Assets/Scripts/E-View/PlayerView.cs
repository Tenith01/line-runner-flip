using UniRx;
using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour
{
    [Inject] private IPlayerPresenter playerPresenter;

    private void Start()
    {
        playerPresenter.moveInputStream.Subscribe(RotatePlayer);
    }

    private void RotatePlayer(float rotateValue)
    {
        if (rotateValue > 0)
        {
            transform.position =new Vector3(-4.04f, 0.8f, 0f);

        }
        else
        {
            transform.position =new Vector3(-4.04f,-0.8f,0f);
        }
    }
}