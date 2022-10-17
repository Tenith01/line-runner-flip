using System;
using UniRx;
using UnityEngine;
using Zenject;

public interface ISessionPresenter
{
    IObservable<int> scoreRx { get; }
    public void PrintScore();
    void AddScore(int score);

    void SetScoreToZero();
}

public class SessionPresenter : MonoBehaviour, ISessionPresenter
{
    [Inject] private ISessionUsecase _sessionUsecase;
    public IObservable<int> scoreRx => _sessionUsecase.sessionStateRx.Select(state => state.score);

    public void PrintScore()
    {
        Debug.Log("Session Presenter is Binded");
    }

    public void AddScore(int score)
    {
        _sessionUsecase.AddScore(score);
    }

    public void SetScoreToZero()
    {
        _sessionUsecase.SetScoreToZero();
    }
}