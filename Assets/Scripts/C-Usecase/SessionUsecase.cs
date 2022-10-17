using System;
using A_Entity;
using UniRx;
using UnityEngine;

public interface ISessionUsecase
{
    IObservable<SessionState> sessionStateRx { get; }
   void AddScore(int scoreValue);
   void SetScoreToZero();
}

public class SessionUsecase : ISessionUsecase
{
    private readonly ReactiveProperty<SessionState> _sessionStateRx = new(new SessionState(0,0));
    public IObservable<SessionState> sessionStateRx => _sessionStateRx;

    public void AddScore(int scoreValue)
    {
        var currentState = _sessionStateRx.Value;
        currentState.score += scoreValue;
        _sessionStateRx.SetValueAndForceNotify(currentState);
    }

    public void SetScoreToZero()
    {
        Debug.Log("score reseted");
        var currentState = _sessionStateRx.Value;
        currentState.score = 0;
        _sessionStateRx.SetValueAndForceNotify(currentState);
    }
}