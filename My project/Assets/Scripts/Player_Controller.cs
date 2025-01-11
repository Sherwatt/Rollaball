using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
//allows the game engine to

public class Player_Controller : MonoBehaviour
{

    public float speed = 0;
    //creates an unseen variable that references the Rigidbody for the physics engine, or something like that
    private Rigidbody rb;

    //these floating points will allow the movementVector to be used in a context where you're only supposed to use Vector3 data
    private float movementX;
    private float movementY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        //creates movementVector variable which stores the directional movement of the player
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

        private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }
    //called when the player collides with a game object
    void OnTriggerEnter(Collider other)
    {
        //checks that the object is in the PickUp catagory
        if(other.gameObject.CompareTag("PickUp"))
        {
            //disables the game object
            other.gameObject.SetActive(false);
        }
        
    }

}
