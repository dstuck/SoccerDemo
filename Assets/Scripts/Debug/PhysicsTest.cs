using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    public float v0 = 2;
    public float x = 0;
    public float y = 0;
    public float v = 0;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        float forceMagnitude = v0 * body.mass / Time.deltaTime;
        body.AddForce(new Vector2(forceMagnitude, 0));
    }

    // Update is called once per frame
    void Update()
    {
        x = body.position.x;
        y = body.position.y;
        v = body.velocity.magnitude;
    }
}
