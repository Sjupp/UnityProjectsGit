using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    AudioSource pain;
    bool facingRight = true;
    bool damaged;
    float speed = 250;
    float movement;
    float damagedTimer;
    float dif;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        pain = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        movement = Input.GetAxisRaw("Horizontal") * speed;
        rb.velocity = (new Vector2(movement * Time.fixedDeltaTime, rb.velocity.y));
        anim.SetFloat("Speed", Mathf.Abs(movement));

        if (movement > 0 && !facingRight)
            Flip();
        else if (movement < 0 && facingRight)
            Flip();

        if (damaged == true)
            Hurt();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = other.transform;
        }
        if (other.gameObject.tag.Equals("Death"))
        {
            pain.Play();
            damaged = true;
            damagedTimer = Time.deltaTime;
            dif = Time.deltaTime;

            if (transform.position.x < 50)
            {
                this.transform.position = new Vector3(-6f, -3.5f, -0.1f);
            }
            if (transform.position.x >= 50 && transform.position.x < 137)
            {
                this.transform.position = new Vector3(50.75f, 0.5f, -0.1f);
            }
        }

        if (other.gameObject.tag.Equals("Finnish"))
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = null;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Hurt()
    {
        dif += Time.deltaTime;

        if (dif - damagedTimer < 0.1)
            sr.color = new Vector4(255, 255, 255, 0);
        else if (dif - damagedTimer < 0.2)
            sr.color = new Vector4(255, 255, 255, 255);
        else if (dif - damagedTimer < 0.3)
            sr.color = new Vector4(255, 255, 255, 0);
        else if (dif - damagedTimer < 0.4)
            sr.color = new Vector4(255, 255, 255, 255);
        else if (dif - damagedTimer < 0.5)
            sr.color = new Vector4(255, 255, 255, 0);
        else if (dif - damagedTimer < 0.6)
            sr.color = new Vector4(255, 255, 255, 255);
        else if (dif - damagedTimer < 0.7)
            sr.color = new Vector4(255, 255, 255, 0);
        else if (dif - damagedTimer < 0.8)
            sr.color = new Vector4(255, 255, 255, 255);
        else if (dif - damagedTimer < 0.9)
            sr.color = new Vector4(255, 255, 255, 0);
        else if (dif - damagedTimer < 1.0)
            sr.color = new Vector4(255, 255, 255, 255);
        else if (dif - damagedTimer < 1.1)
            sr.color = new Vector4(255, 255, 255, 255);
        else if (dif - damagedTimer < 1.2)
            sr.color = new Vector4(255, 255, 255, 0);
        else if (dif - damagedTimer < 1.3)
            sr.color = new Vector4(255, 255, 255, 255);
        else if (dif - damagedTimer < 1.4)
            sr.color = new Vector4(255, 255, 255, 0);
        else if (dif - damagedTimer < 1.5)
            sr.color = new Vector4(255, 255, 255, 255);

        if (dif - damagedTimer > 1.5)
            damaged = false;
    }
}
