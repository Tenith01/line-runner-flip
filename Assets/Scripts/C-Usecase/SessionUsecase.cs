using System;
using A_Entity;
using UniRx;

public interface ISessionUsecase
{
    IObservable<SessionState> sessionStateRx { get; }
    public void AddScore(int scoreValue);
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
}