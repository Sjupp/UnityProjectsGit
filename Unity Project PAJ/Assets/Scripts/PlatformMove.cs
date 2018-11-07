using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    bool moveRight;
    float speed = 3;
    	
	void Update()
    {
        if (transform.position.x < 131)
        {
            moveRight = true;
        }
        if (transform.position.x > 135)
        {
            moveRight = false;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

	}
}
