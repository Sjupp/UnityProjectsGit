using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D rb;
    public bool damaged;
    float damagedTimer;
    float dif;
    public Animator anim;
    public SpriteRenderer sr;
    public BoxCollider2D bc;
    public BoxCollider2D bc2;
    public AudioSource pain;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed;
        rb.velocity = (new Vector2(x, rb.velocity.y));
        anim.SetFloat("Speed", Mathf.Abs(x));

        if (x < 0)
        {
            sr.flipX = true;
            bc.offset = new Vector2(-0.285f, 0.32f);
            bc2.offset = new Vector2(-0.285f, -0.075f);
        }
        if (x > 0)
        {
            sr.flipX = false;
            bc.offset = new Vector2(0.285f, 0.32f);
            bc2.offset = new Vector2(0.285f, 0.075f);
        }

        if (damaged == true)
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
}
