using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGoal : MonoBehaviour
{
    Referee _ref;
    TeamManagement _team;

    // Start is called before the first frame update
    void Start()
    {
        _team = GetComponentInParent<TeamManagement>();
        _ref = GetComponentInParent<Referee>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            _ref.scoredGoal(_team);
        }
    }
}
