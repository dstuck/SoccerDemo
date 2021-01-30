using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Referee : MonoBehaviour
{

    TeamManagement[] teams;
    Rigidbody2D ball;
    Vector2 zeroVec = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        teams = GetComponentsInChildren<TeamManagement>();
        ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scoredGoal(TeamManagement scoringTeam)
    {
        scoringTeam.scoredGoal();
        foreach (TeamManagement team in teams)
        {
            if (team != scoringTeam)
            {
                team.scoredOn();
            }
        }
        ball.position = zeroVec;
        ball.velocity = zeroVec;
    }

}
