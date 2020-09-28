using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class Runner : MonoBehaviour
{
    public float maxSpeed = 9.0f;
    public float maxAcc = 9.0f;

    Vector2 curVelocity = new Vector2(0, 0);

    public float curSpeed { get { return curVelocity.magnitude; } }

    TeamControls controls;
    Vector2 targetDirection = new Vector2(0, 0);
    Rigidbody2D playerRigidbody2d;
    PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody2d = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnEnable()
    {
        if (controls == null)
        {
            controls = new TeamControls();
        }
        controls.Team.Enable();

    }

    public void OnDisable()
    {
        controls.Team.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        targetDirection = playerInput.actions["Movement"].ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (targetDirection.sqrMagnitude > 1.0f)
        {
            targetDirection.Normalize();
        }
        updateCurVelocity(targetDirection * maxSpeed);

        playerRigidbody2d.MovePosition(playerRigidbody2d.position + curVelocity * Time.deltaTime);
    }

    void updateCurVelocity(Vector2 desiredVelocity)
    {
        float relDiffOfMaxSpeed = 1.0f - (maxSpeed - curSpeed) / maxSpeed;
        float possibleVelocityRadius = maxAcc * Time.deltaTime;
        Vector2 possibleVelocityBallCenter = curVelocity;
        if (!Mathf.Approximately(curSpeed, 0.0f))
        {
            possibleVelocityBallCenter = (1.0f - relDiffOfMaxSpeed * possibleVelocityRadius / curSpeed) * curVelocity;
        }

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

}
