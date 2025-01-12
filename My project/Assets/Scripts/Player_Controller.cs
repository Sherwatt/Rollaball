using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
//allows the game engine to

public class Player_Controller : MonoBehaviour
{

    public float speed = 0;

    public TextMeshProUGUI countText;
    //creates an unseen variable that references the Rigidbody for the physics engine, or something like that
    private Rigidbody rb;
    //creates the int value used for showing the player's score
    private int count;

    public GameObject winTextObject;

    //these floating points will allow the movementVector to be used in a context where you're only supposed to use Vector3 data
    private float movementX;
    private float movementY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winTextObject.SetActive(false); //hides the win text at the start of the game
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnMove(InputValue movementValue)
    {
        //creates movementVector variable which stores the directional movement of the player
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true); //displays win text when all the pickups are collected
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //strange issue here, this is only called if the player has moved
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Destroy(gameObject); //destroys the player
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!"; //shows text
        }
    }

    //called when the player collides with a game object
    void OnTriggerEnter(Collider other)
    {
        //checks that the object is in the PickUp catagory
        if(other.gameObject.CompareTag("PickUp"))
        {
            //disables the game object
            other.gameObject.SetActive(false);
            //increases the count
            count = count + 1;
            //changes the text onscreen
            SetCountText();
        }
        
    }

}
