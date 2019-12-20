using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTiles : MonoBehaviour
{
    [SerializeField]
    private bool leftToRight = true;

    [SerializeField]
    private bool positiveDir = true;

    [SerializeField]
    private float tileSpeed;

    private void Update()
    {
        if(leftToRight)
        {
            if(positiveDir)
            {
                transform.position = new Vector2(transform.position.x + 1 * tileSpeed, 
                                                 transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x - 1 * tileSpeed, 
                transform.position.y);
            }
        }
        else
        {
            if(positiveDir)
            {
                transform.position = new Vector2(transform.position.x,
                                                 transform.position.y + 1 * tileSpeed);
            }
            else
            {
                transform.position = new Vector2(transform.position.x,
                                                 transform.position.y - 1 * tileSpeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.name == "limit")
        {
            positiveDir = !positiveDir;
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!leftToRight)
        {
            if(other.gameObject.name == "limit")
            {
                positiveDir = !positiveDir;
            }
        }
        
        if(other.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }    
    }
}


