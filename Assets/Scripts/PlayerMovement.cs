using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D body;
    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D> ();

        // Check for invalid or missing speed values
        if (speed < 0f) {
            Debug.LogError("[PLAYER] Player speed is not set correctly — it should be a positive value.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    void FixedUpdate()
    { 
        if (horizontal != 0 && vertical != 0) {
            body.velocity = new Vector2((horizontal * speed) * moveLimiter , (vertical * speed) * moveLimiter); 
        } else {
            body.velocity = new Vector2(horizontal * speed, vertical * speed); 
        }
    }
}

