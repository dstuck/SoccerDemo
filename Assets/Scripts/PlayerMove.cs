using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed = 9.0f;
    public float maxAcc = 9.0f;
    public float maxKickForce = 1000.0f;
    public float kickRange = 1.0f;

    bool _hasBall = false;
    public bool hasBall { get { return _hasBall; } set { _hasBall = value; } }

    Rigidbody2D playerRigidbody2d;
    Rigidbody2D _ballRigidbody2d;
    BallGoal _ballGoal;
    PhysicsPredictor ballPredictor;

    Vector2 curVelocity = new Vector2(0, 0);
    public float curSpeed { get { return curVelocity.magnitude; } }

    float _kickDistance = 0.1f;
    float _kickDelay = 0.1f;
    float _kickTimer;
    float _POSITION_ERROR = 0.00001f;

    float _planTimer;
    float _planDelayTime = 0.05f;
    Vector2 targetPosition;
    Vector2 targetVelocity;

    //Animator animator;

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
        targetVelocity = new Vector2(0, 0);
        GetComponent<SpriteRenderer>().color = GetComponentInParent<TeamManagement>().teamColor;
    }

    // Update is called once per frame
    void Update()
    {
        _planTimer += Time.deltaTime;
        _kickTimer += Time.deltaTime;
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
        Vector2 desiredVelocity = getDesiredVelocity(targetPosition);
        updateCurVelocity(desiredVelocity);

        Vector2 newPosition = targetPosition;
        if ((targetPosition - playerRigidbody2d.position).magnitude > curSpeed * Time.deltaTime * 0.5f)
        {
            newPosition = playerRigidbody2d.position + curVelocity * Time.deltaTime;
        }
        else
        {
            if (hasBall) { Debug.Log("using targetPosition"); }
        }
        playerRigidbody2d.MovePosition(newPosition);

        if (
            _ballGoal.movementGoal.magnitude > _POSITION_ERROR
            && (playerRigidbody2d.position - targetPosition).magnitude < _POSITION_ERROR
            && _kickTimer > _kickDelay
            )
        {
            Kick(ballPredictor.PredictForceToReachPoint(_ballGoal.targetPosition).magnitude);
            hasBall = false;
        }
    }

    void UpdateMoveGoal()
    {
        Vector2 ballTargetPosition = _ballGoal.movementGoal;
        targetVelocity = ballTargetPosition / 2.0f;
        ballTargetPosition.Normalize();
        targetPosition = _ballRigidbody2d.position - ballTargetPosition * _kickDistance;
    }

    void updateCurVelocity(Vector2 desiredVelocity)
    {
        if (hasBall)
        { Debug.Log(name + " desiredVelocity: " + desiredVelocity + ", curVelocity: " + curVelocity); }
        
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

    Vector2 getDesiredVelocity(Vector2 desiredPosition)
    {
        Vector2 targetDistance = desiredPosition - playerRigidbody2d.position;
        float goalTime = targetDistance.magnitude / curSpeed;
        float stoppingTime = Mathf.Abs(curSpeed - targetVelocity.magnitude) / maxAcc;
        if (goalTime < stoppingTime)
        {
            return targetVelocity;
        }
        Vector2 desiredVelocity = (targetDistance) / Time.deltaTime;
        return desiredVelocity;
    }

    void Kick(float kickForce)
    {
        Vector2 diff_vec = _ballRigidbody2d.position - playerRigidbody2d.position;
        if (diff_vec.magnitude <= kickRange)
        {
            Debug.Log("Kicking with force, direction: " + kickForce + ", " + diff_vec);
            diff_vec.Normalize();
            _ballRigidbody2d.AddForce(diff_vec * Mathf.Clamp(kickForce, 0, maxKickForce));
            _kickTimer = 0.0f;
        }
    }
}
