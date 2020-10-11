using UnityEngine;
using UnityEngine.AI;

public class Idle : IState
{
    private SoccerPlayer _player;

    public Idle(SoccerPlayer player)
    {
        _player = player;
    }

    public void OnEnter()
    {
        _player.TargetPosition = _player.soccerPosition.GetCenterPosition();
    }

    public void Tick()
    {
    }

    public void OnExit()
    {
    }
}
