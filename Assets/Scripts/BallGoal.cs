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

    float kickFactor = 4.0f;


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

        if (Input.GetKey(KeyCode.C))
        {
            distanceFactor *= kickFactor;
        }

        _movementGoal.Set(horizontal, vertical);

        // If we're using a square input, force it back into a unit circle
        if (_movementGoal.SqrMagnitude() > 1)
        {
            _movementGoal.Normalize();
        }
        _movementGoal *= distanceFactor;
    }

    float _calculateVelocityFromForce(float F)
    {
        return (F / ballRigidbody2d.mass) * Time.fixedDeltaTime;
    }

    float _calculateFinalPositionFromVelocity(float V)
    {
        return V / ballRigidbody2d.drag;
    }

    float _distanceFromForce(float F)
    {
        return F * Time.fixedDeltaTime / ballRigidbody2d.mass / ballRigidbody2d.drag;
    }

    float getMetersPerNewtonFactor()
    {
        // This converts an instantaneous force into the distance the ball will travel
        return Time.fixedDeltaTime / ballRigidbody2d.mass / ballRigidbody2d.drag;
    }
}
