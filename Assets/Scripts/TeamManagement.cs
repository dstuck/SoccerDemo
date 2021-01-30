using System.Linq;using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TeamManagement : MonoBehaviour
{
    public Color teamColor = new Color(255, 255, 255, 255);
    public Text scoreboard;

    int score = 0;
    public bool isKickoff;
    Rigidbody2D ballRigidbody2d;
    PhysicsPredictor ballPredictor;
    Rigidbody2D[] teamPlayerRigidbody2ds;
    SoccerPlayer[] teamPlayers;
    BallGoal ballGoal;
    //TeamControls controls;

    public Vector2 ballMovementGoal { get { return ballGoal.movementGoal; } }
    public Vector2 ballTargetPosition { get { return ballGoal.movementGoal + ballRigidbody2d.position; } }


    float predictionHorizon = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody2d = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        ballPredictor = GameObject.FindWithTag("Ball").GetComponent<PhysicsPredictor>();
        ballGoal = GameObject.FindWithTag("Ball").GetComponent<BallGoal>();
        teamPlayerRigidbody2ds = GetComponentsInChildren<Rigidbody2D>();
        teamPlayers = GetComponentsInChildren<SoccerPlayer>();
        //AssignBallToPlayer();
        _updateScoreboard();
    }

    // Update is called once per frame
    void Update()
    {
        if (!teamPlayers.Select(x => x.hasBall).Aggregate(false, (x, y) => x || y))
        {
            AssignBallToPlayer();
        }
        isKickoff = false;
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
        closest_player.gameObject.GetComponent<SoccerPlayer>().hasBall = true;
    }

    public float GetDirection()
    {
        return transform.localScale.x;
    }

    public void scoredGoal()
    {
        score += 1;
        _updateScoreboard();
        resetTeam();
    }

    public void scoredOn()
    {
        resetTeam();
    }

    private void _updateScoreboard()
    {
        Vector2 anchorPoint = new Vector2(0.0f, 1.0f);
        float offset = 20.0f;
        if (GetDirection() < 0.0f)
        {
            anchorPoint.x = 1.0f;
            offset *= -1.0f;
        }
        Vector2 newAnchorPosition = new Vector2(offset, -50.0f);

        scoreboard.rectTransform.anchorMin = anchorPoint;
        scoreboard.rectTransform.anchorMax = anchorPoint;
        scoreboard.rectTransform.anchoredPosition = newAnchorPosition;
        scoreboard.text = score.ToString();
    }
    private void resetTeam()
    {
        isKickoff = true;
    }
}
