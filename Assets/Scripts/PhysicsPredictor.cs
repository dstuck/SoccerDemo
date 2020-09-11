using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPredictor : MonoBehaviour
{
    Rigidbody2D thisRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 PredictPositionInFuture(float t)
    {
        float drag = thisRigidBody.drag;
        if (t * drag > 4.0f)
        {
            // Long time drag approximation
            return thisRigidBody.position + thisRigidBody.velocity / drag;
        }
        if (t * drag < 0.01f)
        {
            // Small time on 1/drag time-scale approximation
            return thisRigidBody.position + thisRigidBody.velocity * (t - 0.5f * t * t * drag * drag);
        }
        // Exact compute
        return thisRigidBody.position + thisRigidBody.velocity / drag * (1 - Mathf.Exp(-t * drag));
    }

    float _calculateVelocityFromForce(float F)
    {
        return (F / thisRigidBody.mass) * Time.fixedDeltaTime;
    }

    float _calculateFinalPositionFromVelocity(float V)
    {
        return V / thisRigidBody.drag;
    }

    float _distanceFromForce(float F)
    {
        return F * Time.fixedDeltaTime / thisRigidBody.mass / thisRigidBody.drag;
    }

    float getMetersPerNewtonFactor()
    {
        // This converts an instantaneous force into the distance the ball will travel
        return Time.fixedDeltaTime / thisRigidBody.mass / thisRigidBody.drag;
    }
}
