using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour
{
    public float speed = -2f;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        // Give meteor an initial downward velocity
        rigidBody.velocity = new Vector2(0, speed);
    }
}
