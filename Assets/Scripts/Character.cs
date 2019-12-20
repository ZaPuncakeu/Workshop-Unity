using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Character : MonoBehaviour
{

    protected Animator anim;

    [SerializeField]
    protected float movespeed;

    [SerializeField]
    protected int health;

    [SerializeField]
    protected float jumpHeight;

    protected Rigidbody2D rigb;

    [SerializeField]
    private float radius;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private GameObject groundcheck;

    [SerializeField]
    protected bool lookingRight = true;

    protected bool isAlive()
    {
        return health > 0;
    }

    public void recieveDamage(int damage)
    {
        health -= damage;
        health = health <= 0 ? 0 : health;

        if(isAlive())
        {
            JumpHurt();
        } 
    }

    public void JumpHurt()
    {
        rigb.velocity = new Vector3(rigb.velocity.x, jumpHeight);
    }

    protected bool grounded()
    {
        return Physics2D.OverlapCircle(groundcheck.transform.position, radius, whatIsGround);
    }
    
}
