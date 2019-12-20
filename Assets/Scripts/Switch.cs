using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private static int nbSwitch = 0;

    private bool isOn = false;

    private bool counted = false;

    [SerializeField]
    private Sprite[] switchSpr = new Sprite[2];

    SpriteRenderer sprRend;

    private void Awake()
    {
        sprRend = GetComponent<SpriteRenderer>();
        sprRend.sprite = switchSpr[0];
        nbSwitch = 0;
    }

    private void Start()
    {
        Debug.Log(++nbSwitch);
    }

    public static int getnbSwitch()
    {
        return nbSwitch;
    }

    bool can_use = false;

    private void Update()
    {
        if(Input.GetButtonDown("Interact") && can_use)
        {
            if(!isOn)
            {
                nbSwitch--;
                isOn = true;
                sprRend.sprite = switchSpr[1];
            }
            else
            {
                nbSwitch++;
                isOn = false;
                sprRend.sprite = switchSpr[0];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            can_use = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            can_use = false;
        }    
    }
}