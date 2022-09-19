using System;
using UniRx;
using UnityEngine;
using Zenject;

public interface IInputGateway
{
    IObservable<float> moveInputStream { get; }
}

public class InputGateway : IInputGateway, ITickable
{
    private readonly Subject<float> _moveInputStream = new();

    private float moveY;
    public IObservable<float> moveInputStream => _moveInputStream;

    public void Tick()
    {
        moveY = Input.GetAxis("Mouse Y");
        if (Input.GetMouseButton(0)) _moveInputStream.OnNext(moveY);
    }
}