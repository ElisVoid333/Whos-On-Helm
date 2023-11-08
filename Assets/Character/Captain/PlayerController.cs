using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    private float speed;
    private float inputX;
    private float inputY;
    private bool moveable;

    public Collider2D playableArea;

    private Vector2 position;
    private Vector2 cleaningTask;
    private Vector2 repairTask;

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


        Vector2 movement = new Vector2(inputX, inputY);
        //movement *= Time.deltaTime;
        transform.Translate(movement);
        inputX = 0;
        inputY = 0;

        // Get player input (e.g., using Input.GetAxis) and calculate the new position.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;


        newPosition.x = Mathf.Clamp(newPosition.x, playableArea.bounds.min.x, playableArea.bounds.max.x);
        newPosition.y = Mathf.Clamp(newPosition.y, playableArea.bounds.min.y, playableArea.bounds.max.y);

        transform.position = newPosition;

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
}
