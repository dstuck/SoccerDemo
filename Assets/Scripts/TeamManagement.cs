using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManagement : MonoBehaviour
{
    Rigidbody2D ballRigidbody2d;
    Rigidbody2D[] teamPlayerRigidbody2ds;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody2d = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        teamPlayerRigidbody2ds = GetComponentsInChildren<Rigidbody2D>();
        AssignBallToPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Rigidbody2D closest_player = GetClosestPlayer(ballRigidbody2d.position);
        closest_player.gameObject.GetComponent<PlayerMove>().hasBall = true;
    }
}
