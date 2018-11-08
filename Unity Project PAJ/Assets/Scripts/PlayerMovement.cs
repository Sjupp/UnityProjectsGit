using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;
    public BoxCollider2D bc;
    public BoxCollider2D bc2;

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
        if (x>0)
        {
            sr.flipX = false;
            bc.offset = new Vector2(0.285f, 0.32f);
            bc2.offset = new Vector2(0.285f, 0.075f);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = other.transform;
        }
        if (other.gameObject.tag.Equals("Death"))
        {
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
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = null;
        }
    }
}
