using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed = 4.7f;
    public float maxKickForce = 1000.0f;
    public float kickRange = 1.0f;

    bool _hasBall = false;
    public bool hasBall { get { return _hasBall; } set { _hasBall = value; } }

    Rigidbody2D playerRigidbody2d;
    Rigidbody2D _ballRigidbody2d;
    BallGoal _ballGoal;
    PhysicsPredictor ballPredictor;
    float _kickDistance = 0.1f;
    float _kickDelay = 0.1f;
    float _kickTimer;
    float _POSITION_ERROR = 0.00001f;

    float _planTimer;
    float _planDelayTime = 0.05f;
    Vector2 targetPosition;

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
            //Debug.Log("targetPosition = " + targetPosition);
            _planTimer = 0.0f;
        }
    }

    void FixedUpdate()
    {
        Vector2 moveDir = targetPosition - playerRigidbody2d.position;
        if (moveDir.magnitude > maxSpeed * Time.deltaTime)
        {
            moveDir.Normalize();
            moveDir *= maxSpeed * Time.deltaTime;
        }

        playerRigidbody2d.MovePosition(playerRigidbody2d.position + moveDir);

        if (
            _ballGoal.movementGoal.magnitude > _POSITION_ERROR
            && (playerRigidbody2d.position - targetPosition).magnitude < _POSITION_ERROR
            && _kickTimer > _kickDelay
            )
        {
            Kick(ballPredictor.PredictForceToReachPoint(_ballGoal.targetPosition).magnitude);
            hasBall = false; // still too close to ball
        }
    }

    void UpdateMoveGoal()
    {
        Vector2 ballTargetPosition = _ballGoal.movementGoal;
        ballTargetPosition.Normalize();
        targetPosition = _ballRigidbody2d.position - ballTargetPosition * _kickDistance;
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
