using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class BallGoal : MonoBehaviour
{
    public float baseDistanceGoal = 2f;
    Rigidbody2D ballRigidbody2d;
    Vector2 _movementGoal = new Vector2(0, 0);
    public Vector2 movementGoal { get { return _movementGoal; } }
    public Vector2 targetPosition { get { return _movementGoal + ballRigidbody2d.position; } }
    TeamControls controls;
    PlayerInput playerInput;
    private Keyboard kb; //hack around webgl input incompatability

    float kickFactor = 4.0f;


    void Start()
    {
        ballRigidbody2d = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        kb = Keyboard.current;
        InputUser.PerformPairingWithDevice(Keyboard.current, user: playerInput.user);
        playerInput.user.ActivateControlScheme(playerInput.defaultControlScheme);
    }

    public void OnEnable()
    {
        if (kb == null)
        {
            controls = new TeamControls();
            // Tell the "gameplay" action map that we want to get told about
            // when actions get triggered.
            //controls.Team1.SetCallbacks(this);
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
        if (kb != null)
        {
            _movementGoal = playerInput.actions["Movement"].ReadValue<Vector2>();

            float distanceFactor = baseDistanceGoal;

            if (playerInput.actions["Kick"].ReadValue<float>() > 0.0f)
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
        else
        {
            kb = Keyboard.current; // as a workaround: keep assigning the device value until it's not null
        }
    }
}
