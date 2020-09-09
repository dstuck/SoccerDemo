using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3.0f;
    public float kickForce = 1000.0f;
    public float kickRange = 0.075f;
    public float dribbleForce = 250.0f;
    public float dribbleDelay = 0.3f;

    Rigidbody2D playerRigidbody2d;
    Rigidbody2D _ballRigidbody2d;
    float horizontal;
    float vertical;

    bool _is_dribbling;
    float _dribble_timer;
    //public bool HasBall { get { return _is_dribbling; } }

    //Animator animator;
    Vector2 moveVector = new Vector2(1, 0);

    void Start()
    {
        //animator = GetComponent<Animator>();
        playerRigidbody2d = GetComponent<Rigidbody2D>();
        _ballRigidbody2d = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        _is_dribbling = false;
        _dribble_timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 lookDirection = new Vector2(horizontal, vertical);
        moveVector.Set(lookDirection.x, lookDirection.y);

        if (!Mathf.Approximately(lookDirection.x, 0.0f) || !Mathf.Approximately(lookDirection.y, 0.0f))
        {
            lookDirection.Normalize();
        }

        //animator.SetFloat("Look X", lookDirection.x);
        //animator.SetFloat("Look Y", lookDirection.y);
        //animator.SetFloat("Speed", move.magnitude);

        _dribble_timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.C))
        {
            Kick();
        }
    }

    void FixedUpdate()
    {
        Vector2 position = playerRigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        playerRigidbody2d.MovePosition(position);
        //rigidbody2d.transform.Translate()
        if (_is_dribbling && (_dribble_timer > dribbleDelay))
        {
            Dribble();
        }
    }

    void Kick()
    {
        Vector2 diff_vec = _ballRigidbody2d.position - playerRigidbody2d.position;
        //Debug.Log(diff_vec + " " + diff_vec.SqrMagnitude());
        if (diff_vec.SqrMagnitude() <= kickRange)
        {
            diff_vec.Normalize();
            _ballRigidbody2d.AddForce(diff_vec * kickForce);
        }
    }

    void Dribble()
    {
        _dribble_timer = 0;
        Vector2 pathToFuturePosition = _ballRigidbody2d.GetPoint(playerRigidbody2d.GetRelativePoint(moveVector));
        Debug.Log("Dribble" + pathToFuturePosition);
        _ballRigidbody2d.AddForce(pathToFuturePosition * dribbleForce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball entered collider");
            _is_dribbling = true;
            //other.GetComponent<Rigidbody2D>().AddForce(lookDirection * dribbleForce);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball exited collider");
            _is_dribbling = false;        }
    }
}

