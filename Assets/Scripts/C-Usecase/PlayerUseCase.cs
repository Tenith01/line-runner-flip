using System;
using Zenject;

public interface IPlayerUseCase
{
    IObservable<float> moveInputStream { get; }
}

public class PlayerUseCase : IPlayerUseCase
{
    [Inject] private IInputGateway _gateway;
    public IObservable<float> moveInputStream => _gateway.moveInputStream;
}