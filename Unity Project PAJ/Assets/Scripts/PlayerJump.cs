using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    float jumpMaxTime;
    float jumpTime;
    bool isJumping;
    float jumpPower;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 2;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            isJumping = true;
            jumpMaxTime = Time.time + 0.65f;
            jumpTime = 0;
            jumpPower = 2.4f;
        }

        if (Input.GetButton("Jump") && Time.time < jumpMaxTime)
        {
            jumpTime += Time.deltaTime;

            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);

            if (jumpTime < 0.45)
            {
                if (jumpPower < 8)
                    jumpPower *= 1.2f;
                else
                    jumpPower *= 0.8f;
            }

        }

        if (Input.GetButtonUp("Jump"))
        {
            jumpMaxTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isJumping = false;
    }
}