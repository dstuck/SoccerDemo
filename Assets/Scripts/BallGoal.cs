using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGoal : MonoBehaviour
{
    public float baseDistanceGoal = 2;
    Rigidbody2D ballRigidbody2d;
    float horizontal;
    float vertical;
    public Vector2 _movementGoal = new Vector2(0, 0);
    public Vector2 movementGoal { get { return _movementGoal; } }


    void Start()
    {
        ballRigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        float distanceFactor = baseDistanceGoal;

        _movementGoal.Set(horizontal, vertical);
        _movementGoal *= distanceFactor;

    }
}
