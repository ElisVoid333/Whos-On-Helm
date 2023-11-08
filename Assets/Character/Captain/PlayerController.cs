using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    private float speed;
    private float inputX;
    private float inputY;
    private bool moveable;

    public Collider2D playableArea;

    public float moveSpeed = 5f;
    public string boundaryTag = "Border"; // Use the tag you assigned to your colliders.


    // Start is called before the first frame update
    void Start()
    {
        inputX = 0; inputY = 0;
        speed = 0.005f;
        moveable = true;
        
        position = new Vector2(0, 0);
        repairTask = new Vector2(-2.12f, -1.10f);
        cleaningTask = new Vector2(2.50f, 1.25f);


    }

    // Update is called once per frame
    void Update()
    {
        if (moveable)
        {
            speed = 0.005f;
        }
        if (moveable == false)
        {
            speed = 0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            inputY += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputY -= speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputX -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputX += speed;
        }


        //Vector2 movement = new Vector2(inputX, inputY);
        //movement *= Time.deltaTime;
        // transform.Translate(movement);


        // inputX = 0;
        //inputY = 0;

        // Get input for player movement
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //// Calculate the player's new position
        //Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        //// Check if the new position is outside any colliders with the "border" tag
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.1f);
        //foreach (Collider2D collider in colliders)
        //{
        //    if (collider.CompareTag("Border"))
        //    {
        //        // If the new position is outside a border collider, clamp the position
        //        newPosition = new Vector3(
        //            Mathf.Clamp(newPosition.x, collider.bounds.min.x, collider.bounds.max.x),
        //            Mathf.Clamp(newPosition.y, collider.bounds.min.y, collider.bounds.max.y),
        //            transform.position.z
        //        );
        //    }
        //}

        //// Apply the new position to the player
        //transform.position = newPosition;

        // Get input for player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the player's new position
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // Check if the new position is inside or overlapping any colliders with the "border" tag
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.1f);
        bool canMove = true;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Border"))
            {
                // If the new position is inside or overlapping a border collider, prevent movement
                canMove = false;
                break;
            }
        }

        // Apply the new position to the player if movement is allowed
        if (canMove)
        {
            transform.position = newPosition;
        }



    }

    public void moveCaptain(string role)
    {
        if (role == "cleaner")
        {
            position = cleaningTask;
            transform.position = position;
        }
        else if (role == "repair")
        {
            position = repairTask;
            transform.position = position;
        }
    }




    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Role") 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(collision.gameObject.tag);
                //Interact with role
                if (moveable)
                {
                    Debug.Log("Interacting with role");
                    moveable = false;
                }
                if (moveable == false)
                {
                    Debug.Log("Leaving role");
                    moveable = true;
                }
            }
        }
    }
}
