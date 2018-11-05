using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D Rigidbody2D;

    void Start ()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
	

	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed;
        Rigidbody2D.velocity = (new Vector2(x, Rigidbody2D.velocity.y));
    }
}
