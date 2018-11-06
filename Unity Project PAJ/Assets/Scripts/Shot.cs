using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public float speed;

    Rigidbody2D rb;

    private Transform target;
    private Vector2 moveDirection;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("PlayerTest").transform;

        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		
	}

    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "PlayerTest")
        {
            DestroyShot();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTest"))
        {
            DestroyShot();
        }
    }

    void DestroyShot()
    {
        Destroy(gameObject);
    }
}
