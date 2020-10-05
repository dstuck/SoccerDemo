using UnityEngine;
using UnityEngine.AI;

public class HasBall : IState
{
    private SoccerPlayer _player;
    private readonly TeamManagement _team;
    private readonly BallGoal _goal;
    private readonly Rigidbody2D _ball;

    float _planTimer;
    float _planDelayTime = 0.05f;

    public HasBall(SoccerPlayer player, TeamManagement team, BallGoal ballGoal, Rigidbody2D ball)
    {
        _player = player;
        _team = team;
        _goal = ballGoal;
        _ball = ball;

    }

    public void OnEnter()
    {
        _planTimer = 0.0f;
        Debug.Log("I got the ball");
    }

    public void Tick()
    {
        _planTimer += Time.deltaTime;
        if (_planTimer > _planDelayTime)
        {
            _player.TargetPosition = _ball.position;
        }
    }

    public void OnExit()
    {
        Debug.Log("I lost the ball");
    }
}
