using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGoal : MonoBehaviour
{
    TeamManagement _team;

    // Start is called before the first frame update
    void Start()
    {
        _team = GetComponentInParent<TeamManagement>();
        //_ballRigidbody2d = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collission with tag " + other.tag);
        if (other.tag == "Ball")
        {
            _team.scoredGoal();
        }
    }
}
