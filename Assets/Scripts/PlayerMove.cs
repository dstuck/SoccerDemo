using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3.0f;
    public float kickForce = 1000.0f;
    public float kickRange = 0.075f;

    Rigidbody2D playerRigidbody2d;
    Rigidbody2D _ballRigidbody2d;
    float horizontal;
    float vertical;

    //Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    void Start()
    {
        //animator = GetComponent<Animator>();
        playerRigidbody2d = GetComponent<Rigidbody2D>();
        _ballRigidbody2d = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        //animator.SetFloat("Look X", lookDirection.x);
        //animator.SetFloat("Look Y", lookDirection.y);
        //animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.C))
        {
            Kick();
        }
    }

    void Kick()
    {
        Vector2 diff_vec = _ballRigidbody2d.position - playerRigidbody2d.position;
        Debug.Log(diff_vec + " " + diff_vec.SqrMagnitude());
        if (diff_vec.SqrMagnitude() <= kickRange)
        {
            diff_vec.Normalize();
            _ballRigidbody2d.AddForce(diff_vec * kickForce);
        }
    }

    void FixedUpdate()
    {
        Vector2 position = playerRigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        playerRigidbody2d.MovePosition(position);
        //rigidbody2d.transform.Translate()
    }
}


