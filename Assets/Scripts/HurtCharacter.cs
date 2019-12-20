using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtCharacter : MonoBehaviour
{
    [SerializeField]
    private int damage;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Character chara = other.GetComponent<Character>();
            chara.recieveDamage(damage);
        }
    }
}
