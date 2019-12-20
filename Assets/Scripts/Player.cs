using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    private float horizontal;

    [SerializeField]
    private GameObject gameOver;

    private bool can_retry = false;

    private void Start()
    {
        rigb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("isalive",isAlive());

        if(isAlive())
        {
            Moves();
        }
        else
        {
            rigb.velocity = new Vector2(0, rigb.velocity.y);
            if(can_retry)
            {
                if(Input.GetButtonDown("Retry"))
                {
                    Scene scene = SceneManager.GetActiveScene(); 
                    SceneManager.LoadScene(scene.name);
                }
            }
        }
    }

    private void Moves()
    {
        Walk();
        Jump();
    }

    private void Walk()
    {
        horizontal = Input.GetAxis("Horizontal");
        rigb.velocity = new Vector3(horizontal * movespeed, rigb.velocity.y);
        anim.SetFloat("movespeed",Mathf.Abs(horizontal));
        anim.SetBool("grounded", grounded());

        if((horizontal < 0 && lookingRight) || (horizontal > 0 && !lookingRight))
        {
            lookingRight = !lookingRight;
            Flip();
        }
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(grounded())
            {
                rigb.velocity = new Vector3(rigb.velocity.x, jumpHeight);
            }
        }
    }

    private void GameOver()
    {
        can_retry = true;
        gameOver.SetActive(true);
    }

    private void Flip()
    {
        Vector3 currScale = transform.localScale;
        currScale.x *= -1;
        transform.localScale = currScale;
    }
}
