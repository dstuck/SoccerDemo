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

    private StateMachine _stateMachine;

    bool _hasBall = false;
    public bool hasBall { get { return _hasBall; } set { _hasBall = value; } }

    Rigidbody2D playerRigidbody2d;
    Rigidbody2D _ballRigidbody2d;
    BallGoal _ballGoal;
    PhysicsPredictor ballPredictor;

    Vector2 curVelocity = new Vector2(0, 0);
    public float curSpeed { get { return curVelocity.magnitude; } }

    float _kickDelay = 0.1f;
    float _kickTimer;
    float _POSITION_ERROR = 0.00001f;

    float _planTimer;
    float _planDelayTime = 0.05f;
    Vector2 targetPosition;

    //Animator animator;

    private void Awake()
    {
    }
    void Start()
    {
        //animator = GetComponent<Animator>();
        playerRigidbody2d = GetComponent<Rigidbody2D>();
        _ballRigidbody2d = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        _ballGoal = GetComponentInParent<BallGoal>();
        ballPredictor = GameObject.FindWithTag("Ball").GetComponent<PhysicsPredictor>();
        _planTimer = 0.0f;
        _kickTimer = _kickDelay;
        targetPosition = playerRigidbody2d.position;
        GetComponent<SpriteRenderer>().color = GetComponentInParent<TeamManagement>().teamColor;

        _stateMachine = new StateMachine();

        var idle = new Idle();
        var hasBallState = new HasBall(GetComponentInParent<TeamManagement>(), _ballGoal);

        //var moveToSelected = new MoveToSelectedResource(this, navMeshAgent, animator);

        At(idle, hasBallState, () => hasBall);
        At(hasBallState, idle, () => !hasBall);

        //At(flee, search, () => enemyDetector.EnemyInRange == false);

        _stateMachine.SetState(idle);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);
    }

    // Update is called once per frame
    void Update()
    {
        _planTimer += Time.deltaTime;
        _kickTimer += Time.deltaTime;
        _stateMachine.Tick();
        if (hasBall && _planTimer > _planDelayTime)
        {
            UpdateMoveGoal();
            //Debug.Log(name + " targetPosition = " + targetPosition);
            _planTimer = 0.0f;
            hasBall = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = (targetPosition - playerRigidbody2d.position) / Time.deltaTime;
        updateCurVelocity(targetVelocity);

        Vector2 newPosition = targetPosition;
        if (curVelocity != targetVelocity)
        {
            newPosition = playerRigidbody2d.position + curVelocity * Time.deltaTime;
        }
        playerRigidbody2d.MovePosition(newPosition);

        if (
            _ballGoal.movementGoal.magnitude > _POSITION_ERROR
            && (playerRigidbody2d.position - _ballRigidbody2d.position).magnitude < Mathf.Max(curSpeed * Time.deltaTime, kickRange)
            && _kickTimer > _kickDelay
            )
        {
            Kick(ballPredictor.PredictForceToReachPoint(_ballGoal.targetPosition));
            hasBall = false;
        }
    }

    void UpdateMoveGoal()
    {
        targetPosition = _ballRigidbody2d.position;
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
        Debug.Log("Kicking with force: " + kickVec);
        _ballRigidbody2d.AddForce(kickVec);
        _kickTimer = 0.0f;

    }
}
