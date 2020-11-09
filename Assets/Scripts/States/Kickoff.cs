using UnityEngine;
using UnityEngine.AI;

public class Kickoff : IState
{
    private SoccerPlayer _player;
    public float kickoffTimer;

    public Kickoff(SoccerPlayer player)
    {
        _player = player;
        kickoffTimer = 0.0f;
    }

    public void OnEnter()
    {
        _player.TargetPosition = _player.soccerPosition.GetKickoffPosition();
        kickoffTimer = 0.0f;
    }

    public void Tick()
    {
        kickoffTimer += Time.deltaTime;
    }

    public void OnExit()
    {
    }
}
