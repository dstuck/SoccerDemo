using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed = 4.7f;
    public float maxKickForce = 1000.0f;
    public float kickRange = 0.3f;

    Rigidbody2D playerRigidbody2d;
    Rigidbody2D _ballRigidbody2d;
    BallGoal _ballGoal;
    float _kickDistance = 0.1f;
    float METERS_PER_NEWTON = 0.02f;
    float _POSITION_ERROR = 0.0001f;

    float _planTimer;
    float _planDelayTime = 0.05f;
    Vector2 targetPosition;

    //Animator animator;

    void Start()
    {
        //animator = GetComponent<Animator>();
        playerRigidbody2d = GetComponent<Rigidbody2D>();
        _ballRigidbody2d = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        _ballGoal = GameObject.FindWithTag("Ball").GetComponent<BallGoal>();
        _planTimer = 0;
        targetPosition = playerRigidbody2d.position;
    }

    // Update is called once per frame
    void Update()
    {
        _planTimer += Time.deltaTime;
        if (_planTimer > _planDelayTime)
        {
            UpdateMoveGoal();
            //Debug.Log("targetPosition = " + targetPosition);
            _planTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Kick(maxKickForce);
        }
    }

    void FixedUpdate()
    {
        //Vector2 position = playerRigidbody2d.position;
        //position.x = position.x + speed * horizontal * Time.deltaTime;
        //position.y = position.y + speed * vertical * Time.deltaTime;
        //Debug.Log("targetPosition =" + targetPosition);
        Vector2 moveDir = targetPosition - playerRigidbody2d.position;
        if (moveDir.magnitude > maxSpeed * Time.deltaTime)
        {
            moveDir.Normalize();
            moveDir *= maxSpeed * Time.deltaTime;
        }

        playerRigidbody2d.MovePosition(playerRigidbody2d.position + moveDir);

        if ((playerRigidbody2d.position - targetPosition).magnitude < _POSITION_ERROR)
        {
            Kick(_ballGoal.movementGoal.magnitude / METERS_PER_NEWTON);
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
        Debug.Log("Kicking with force: " + kickForce);
        if (diff_vec.magnitude <= kickRange)
        {
            diff_vec.Normalize();
            _ballRigidbody2d.AddForce(diff_vec * Mathf.Clamp(kickForce, 0, maxKickForce));
        }
    }
}
