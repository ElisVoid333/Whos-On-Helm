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
    public int captainSelected;
    public SpriteRenderer spriteRenderer;
    public Sprite maleStatic;
    public Sprite femaleStatic;
    public Sprite neutralStatic;

    //Player Animation
    Animator animator;
    string currState;
    string CAP_STATIC = "Cap_Static";
    string CAP_WALK = "Cap_Walk";

    private Vector2 position;
    private Vector2 cleaningTask;
    private Vector2 repairTask;

    // Start is called before the first frame update
    void Start()
    {
        inputX = 0; inputY = 0;
        speed = 0.005f;
        moveable = true;
        if (captainSelected == 0)
        {
            spriteRenderer.sprite = maleStatic;
        }
        else if (captainSelected == 1)
        {
            spriteRenderer.sprite = femaleStatic;
            CAP_STATIC = "CapF_Static";
            CAP_WALK = "CapF_Walk";
        }
        else if (captainSelected == 2)
        {
            spriteRenderer.sprite = neutralStatic;
            CAP_STATIC = "CapN_Static";
            CAP_WALK = "CapN_Walk";
        }
        animator = gameObject.GetComponent<Animator>();
    }

    //Change Animation
    private void ChangeAnimationState(string newState)
    {
        if (newState == currState)
        {
            return;
        }

        animator.Play(newState);
        currState = newState;
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
            ChangeAnimationState(CAP_WALK);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            ChangeAnimationState(CAP_STATIC);
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputY -= speed;
            ChangeAnimationState(CAP_WALK);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            ChangeAnimationState(CAP_STATIC);
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputX -= speed;
            ChangeAnimationState(CAP_WALK);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            ChangeAnimationState(CAP_STATIC);
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputX += speed;
            ChangeAnimationState(CAP_WALK);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            ChangeAnimationState(CAP_STATIC);
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
