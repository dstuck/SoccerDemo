using System.Linq;using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeamManagement : MonoBehaviour
{
    Rigidbody2D ballRigidbody2d;
    PhysicsPredictor ballPredictor;
    Rigidbody2D[] teamPlayerRigidbody2ds;
    PlayerMove[] teamPlayers;
    BallGoal ballGoal;
    //TeamControls controls;

    public Vector2 ballMovementGoal { get { return ballGoal.movementGoal; } }
    public Vector2 targetPosition { get { return ballGoal.movementGoal + ballRigidbody2d.position; } }


    float predictionHorizon = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody2d = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        ballPredictor = GameObject.FindWithTag("Ball").GetComponent<PhysicsPredictor>();
        ballGoal = GameObject.FindWithTag("Ball").GetComponent<BallGoal>();
        teamPlayerRigidbody2ds = GetComponentsInChildren<Rigidbody2D>();
        teamPlayers = GetComponentsInChildren<PlayerMove>();
        //AssignBallToPlayer();
    }

    //public void OnEnable()
    //{
    //    if (controls == null)
    //    {
    //        controls = new TeamControls();
    //        // Tell the "gameplay" action map that we want to get told about
    //        // when actions get triggered.
    //        //controls.Team.SetCallbacks(this);
    //    }
    //    controls.Team.Enable();
    //}

    //public void OnDisable()
    //{
    //    controls.Team.Disable();
    //}

    // Update is called once per frame
    void Update()
    {
        if (!teamPlayers.Select(x => x.hasBall).Aggregate(false, (x, y) => x || y))
        {
            AssignBallToPlayer();
        }
    }

    Rigidbody2D GetClosestPlayer(Vector2 point)
    {
        Rigidbody2D closest_player = null;
        float closest_sq_dist = Mathf.Infinity;

        foreach (Rigidbody2D player in teamPlayerRigidbody2ds)
        {
            float sqr_dist = (player.position - point).SqrMagnitude();
            if (sqr_dist < closest_sq_dist)
            {
                closest_player = player;
                closest_sq_dist = sqr_dist;
            }
        }
        return closest_player;
    }

    void AssignBallToPlayer()
    {
        Vector2 futureBallPosition = ballPredictor.PredictPositionInFuture(predictionHorizon);
        //Debug.Log("Current, future position: " + ballRigidbody2d.position + ", " + futureBallPosition);
        Rigidbody2D closest_player = GetClosestPlayer(futureBallPosition);
        closest_player.gameObject.GetComponent<PlayerMove>().hasBall = true;
    }
}
