using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    float jumpMaxTime;
    float airTime;
    bool isJumping;
    float jumpPower;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            isJumping = true;
            jumpMaxTime = Time.time + 0.35f;
            airTime = 0;
            jumpPower = 5.0f;
        }

        if (Input.GetButton("Jump") && Time.time < jumpMaxTime)
        {
            airTime += Time.deltaTime;

            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            if (airTime < 0.35)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        isJumping = false;
        anim.SetBool("Jumping", false);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isJumping = true;
        anim.SetBool("Jumping", true);
    }
}
