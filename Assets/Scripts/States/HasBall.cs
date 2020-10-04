using UnityEngine;
using UnityEngine.AI;

public class HasBall : IState
{
    private readonly TeamManagement _team;
    private readonly BallGoal _goal;

    public HasBall(TeamManagement team, BallGoal ballGoal)
    {
        _team = team;
        _goal = ballGoal;
    }

    public void OnEnter()
    {
        Debug.Log("I got the ball");
    }

    public void Tick()
    {
    }

    public void OnExit()
    {
        Debug.Log("I lost the ball");
    }
}
