using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    float jumpMaxTime;
    float airTime;
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
            jumpMaxTime = Time.time + 0.35f;
            airTime = 0;
            jumpPower = 3.6f;
        }

        if (Input.GetButton("Jump") && Time.time < jumpMaxTime)
        {
            airTime += Time.deltaTime;

            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);

            if (airTime < 0.35)
            {
                if (jumpPower < 6)
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