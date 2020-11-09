using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour
{
    public float maxSpeed = 9.0f;
    public float maxAcc = 9.0f;
    public float maxKickForce = 1000.0f;
    public float kickRange = 1.0f;
    public PositionNames positionName;
    public SoccerPosition soccerPosition;

    private StateMachine _stateMachine;

    bool _hasBall = false;
    public bool hasBall { get { return _hasBall; } set { _hasBall = value; } }
    Vector2 _targetPosition;
    public Vector2 TargetPosition { get => _targetPosition; set => _targetPosition = value; }
    Vector2 _targetKick;
    public Vector2 TargetKick { get => _targetKick; set => _targetKick = value; }

    Rigidbody2D playerRigidbody2d;
    Rigidbody2D _ballRigidbody2d;
    BallGoal _ballGoal;
    PhysicsPredictor ballPredictor;
    TeamManagement _team;

    Vector2 curVelocity = new Vector2(0, 0);
    public float curSpeed { get { return curVelocity.magnitude; } }

    float _kickDelay = 0.1f;
    float _kickTimer;

    Vector2 zeroVec = new Vector2(0.0f, 0.0f);

    //Animator animator;

    void Start()
    {
        //animator = GetComponent<Animator>();
        playerRigidbody2d = GetComponent<Rigidbody2D>();
        _ballRigidbody2d = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        _ballGoal = GetComponentInParent<BallGoal>();
        ballPredictor = GameObject.FindWithTag("Ball").GetComponent<PhysicsPredictor>();
        _kickTimer = _kickDelay;
        _targetPosition = playerRigidbody2d.position;
        _targetKick = zeroVec;
        _team = GetComponentInParent<TeamManagement>();
        GetComponent<SpriteRenderer>().color = _team.teamColor;

        soccerPosition = SoccerPositionFactory.CreatePositionForName(positionName, _team);

        // State Machine Management
        _stateMachine = new StateMachine();

        var idle = new Idle(this);
        var kickoff = new Kickoff(this);
        var hasBallState = new HasBall(this, GetComponentInParent<TeamManagement>(), _ballGoal, _ballRigidbody2d);

        //var moveToSelected = new MoveToSelectedResource(this, navMeshAgent, animator);

        At(idle, hasBallState, () => hasBall);
        At(hasBallState, idle, () => !hasBall);
        At(idle, kickoff, () => _team.isKickoff);
        At(hasBallState, kickoff, () => _team.isKickoff);
        At(kickoff, idle, () => kickoff.kickoffTimer > 8.0f);

        //At(flee, search, () => enemyDetector.EnemyInRange == false);

        _stateMachine.SetState(idle);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        transform.position = soccerPosition.GetKickoffPosition();
    }

    // Update is called once per frame
    void Update()
    {
        _kickTimer += Time.deltaTime;
        _stateMachine.Tick();
        hasBall = false; // Could add timer here
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = (TargetPosition - playerRigidbody2d.position) / Time.deltaTime;
        updateCurVelocity(targetVelocity);

        Vector2 newPosition = TargetPosition;
        if (curVelocity != targetVelocity)
        {
            newPosition = playerRigidbody2d.position + curVelocity * Time.deltaTime;
        }
        playerRigidbody2d.MovePosition(newPosition);

        if (
            !(Mathf.Approximately(TargetKick.sqrMagnitude, 0.0f))
            && (playerRigidbody2d.position - _ballRigidbody2d.position).magnitude < Mathf.Max(curSpeed * Time.deltaTime, kickRange)
            && _kickTimer > _kickDelay
            )
        {
            Kick(TargetKick);
            _targetKick = zeroVec;
            //hasBall = false;
        }
    }

    void updateCurVelocity(Vector2 desiredVelocity)
    {
        //if (hasBall)
        //{ Debug.Log(name + " desiredVelocity: " + desiredVelocity + ", curVelocity: " + curVelocity); }
        
        float relDiffOfMaxSpeed = 1.0f - (maxSpeed - curSpeed) / maxSpeed;
        float possibleVelocityRadius = maxAcc * Time.deltaTime;
        Vector2 possibleVelocityBallCenter = curVelocity;
        if (!Mathf.Approximately(curSpeed, 0.0f))
        {
            possibleVelocityBallCenter = (1.0f - relDiffOfMaxSpeed * possibleVelocityRadius / curSpeed) * curVelocity;
        }
        //Debug.Log("possibleVelocityBallCenter: " + possibleVelocityBallCenter + " curVelocity: " + curVelocity);
        Vector2 diffVelocity = desiredVelocity - possibleVelocityBallCenter;
        if (diffVelocity.sqrMagnitude < possibleVelocityRadius * possibleVelocityRadius)
        {
            curVelocity = desiredVelocity;
        }
        else
        {
            Vector2 closestPossibleVelocity = possibleVelocityBallCenter + diffVelocity.normalized * possibleVelocityRadius;
            curVelocity = closestPossibleVelocity;
        }
    }

    void Kick(Vector2 kickVec)
    {
        if (kickVec.SqrMagnitude() > maxKickForce * maxKickForce)
        {
            kickVec = kickVec.normalized * maxKickForce;
        }
        //Debug.Log("Kicking with force: " + kickVec);
        _ballRigidbody2d.AddForce(kickVec);
        _kickTimer = 0.0f;

    }

    public void SetKickFromPosition(Vector2 desiredBallPosition)
    {
        TargetKick = ballPredictor.PredictForceToReachPoint(desiredBallPosition);
    }
}
