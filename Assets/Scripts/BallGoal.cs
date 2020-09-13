using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallGoal : MonoBehaviour
{
    public float baseDistanceGoal = 2f;
    Rigidbody2D ballRigidbody2d;
    public Vector2 _movementGoal = new Vector2(0, 0);
    public Vector2 movementGoal { get { return _movementGoal; } }
    public Vector2 targetPosition { get { return _movementGoal + ballRigidbody2d.position; } }
    TeamControls controls;

    float kickFactor = 4.0f;


    void Start()
    {
        ballRigidbody2d = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
    }

    public void OnEnable()
    {
        if (controls == null)
        {
            controls = new TeamControls();
            // Tell the "gameplay" action map that we want to get told about
            // when actions get triggered.
            //controls.Team.SetCallbacks(this);
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
        _movementGoal = controls.Team.Movement.ReadValue<Vector2>();

        float distanceFactor = baseDistanceGoal;

        if (Keyboard.current.cKey.isPressed)
        {
            distanceFactor *= kickFactor;
        }

        // If we're using a square input, force it back into a unit circle
        if (_movementGoal.SqrMagnitude() > 1)
        {
            _movementGoal.Normalize();
        }
        _movementGoal *= distanceFactor;
    }
}
