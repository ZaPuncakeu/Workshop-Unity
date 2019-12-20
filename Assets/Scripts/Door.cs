using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{


    [SerializeField]
    private Sprite[] doorSpr = new Sprite[3];

    SpriteRenderer sprRend;

    private bool isOpen = false;

    private void Awake()
    {
        sprRend = GetComponent<SpriteRenderer>();
        sprRend.sprite = doorSpr[0];
    }

    private void Update()
    {
        if(Switch.getnbSwitch() == 0)
        {
            if(isOpen)
            {
                sprRend.sprite = doorSpr[2];
                if(Input.GetButton("Interact"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else
            {
                sprRend.sprite = doorSpr[1];
            }
        }
        else
        {
            sprRend.sprite = doorSpr[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            isOpen = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            isOpen = false;
        }    
    }
}
