using UnityEngine;
using UnityEngine.AI;

public class HasBall : IState
{
    private SoccerPlayer _player;
    private readonly TeamManagement _team;
    private readonly BallGoal _goal;
    private readonly Rigidbody2D _ball;
    PhysicsPredictor ballPredictor;

    float _planTimer;
    float _planDelayTime = 0.05f;

    float _POSITION_ERROR = 0.00001f;

    public HasBall(SoccerPlayer player, TeamManagement team, BallGoal ballGoal, Rigidbody2D ball)
    {
        _player = player;
        _team = team;
        _goal = ballGoal;
        _ball = ball;
        ballPredictor = _ball.GetComponent<PhysicsPredictor>();

    }

    public void OnEnter()
    {
        _planTimer = 0.0f;
    }

    public void Tick()
    {
        _planTimer += Time.deltaTime;
        if (_planTimer > _planDelayTime)
        {
            _player.TargetPosition = _ball.position;
            _planTimer = 0.0f;
        }

        if(_goal.movementGoal.magnitude > _POSITION_ERROR)
        {
            _player.SetKickFromPosition(_goal.targetPosition);
        }
    }

    public void OnExit()
    {
    }
}
