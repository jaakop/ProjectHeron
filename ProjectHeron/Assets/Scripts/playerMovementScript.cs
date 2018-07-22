using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour {

    public float movementSpeed;
    Rigidbody2D rb;
    [SerializeField]
    KeyCode up;
    [SerializeField]
    KeyCode down;
    [SerializeField]
    KeyCode left;
    [SerializeField]
    KeyCode right;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {

        if (Input.GetKey(up))
        {
            rb.velocity = new Vector2(rb.velocity.x, movementSpeed);
        }
        if (Input.GetKey(down))
        {
            rb.velocity = new Vector2(rb.velocity.x, -movementSpeed);
        }

        if (!Input.GetKey(up) && !Input.GetKey(down))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
        if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }

        if (!Input.GetKey(left) && !Input.GetKey(right))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }
}
