using System;
using UnityEngine;
using Zenject;

public interface IPlayerPresenter
{
    IObservable<float> moveInputStream { get; }
}

public class PlayerPresenter : MonoBehaviour, IPlayerPresenter
{
    [Inject] private IPlayerUseCase playerUseCase;
    public IObservable<float> moveInputStream => playerUseCase.moveInputStream;
}