﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D Rigidbody2D;
    public Animator anim;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed;
        Rigidbody2D.velocity = (new Vector2(x, Rigidbody2D.velocity.y));
        anim.SetFloat("Speed", Mathf.Abs(x));
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = other.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = null;
        }
    }
}
