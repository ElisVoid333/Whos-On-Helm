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

    //public Collider2D playableArea;

    private Vector2 position;
    private Vector2 cleaningTask;
    private Vector2 repairTask;
    private Vector2 canonTask;
    private Vector2 helmTask;

    private int captainSelected;
    public GameController game;
    public SpriteRenderer spriteRenderer;
    public Sprite maleStatic;
    public Sprite femaleStatic;
    public Sprite neutralStatic;

    //Player Animation
    Animator animator;
    string currState;
    string CAP_STATIC = "";
    string CAP_WALK = "";
    string CAP_INTERACT = "";

    //RigidBody
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        inputX = 0; inputY = 0;
        speed = 5f;
        moveable = true;

        position = new Vector2(0, 0);
        repairTask = new Vector2(5.47f, 0.08f);
        cleaningTask = new Vector2(-2.46f, 1.64f);
        canonTask = new Vector2(1.24f, -1.6f);
        helmTask = new Vector2(-6.14f, 0.16f);

        captainSelected = game.getCaptain("Captain");

        //Animation & Captain selection
        if (captainSelected == 0)
        {
            spriteRenderer.sprite = maleStatic;
            CAP_STATIC = "Cap_Static";
            CAP_WALK = "Cap_Walk";
            CAP_INTERACT = "Cap_Interact";
        }
        else if (captainSelected == 1)
        {
            spriteRenderer.sprite = femaleStatic;
            CAP_STATIC = "CapF_Static";
            CAP_WALK = "CapF_Walk";
            CAP_INTERACT = "CapF_Interact";
        }
        else if (captainSelected == 2)
        {
            spriteRenderer.sprite = neutralStatic;
            CAP_STATIC = "CapN_Static";
            CAP_WALK = "CapN_Walk";
            CAP_INTERACT = "CapN_Interact";
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
            speed = 5f;
        }
        if (moveable == false)
        {
            speed = 0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            inputY = speed;
            ChangeAnimationState(CAP_WALK);
            //if tilt is up, speed up
            //get tiltDirection from other script???
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputY = -speed;
            ChangeAnimationState(CAP_WALK);
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputX = -speed;
            ChangeAnimationState(CAP_WALK);
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputX = speed;
            ChangeAnimationState(CAP_WALK);
            spriteRenderer.flipX = false;
        }
        //Key Up - change back to static animation
        if (Input.GetKeyUp(KeyCode.W))
        {
            inputY = 0f;
            ChangeAnimationState(CAP_STATIC);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            inputY = 0f;
            ChangeAnimationState(CAP_STATIC);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            inputX = 0f;
            ChangeAnimationState(CAP_STATIC);
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            inputX = 0f;
            ChangeAnimationState(CAP_STATIC);
            spriteRenderer.flipX = false;
        }


        //Vector2 movement = new Vector2(inputX, inputY);
        //movement *= Time.deltaTime;
        // transform.Translate(movement);


        // inputX = 0;
        //inputY = 0;
        float horizontalInput = inputX;
        float verticalInput = inputY;

        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
        rb.drag = 500f;
        
        /*
        // BORDERS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // transform.position = newPosition;

        // Calculate the player's new position
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

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
        */
        // BORDERS END~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


    }

    public void moveCaptain(string role)
    {
        if (role == "cleaner")
        {
            position = cleaningTask;
            transform.position = position;
            ChangeAnimationState(CAP_INTERACT);
        }
        else if (role == "repair")
        {
            position = repairTask;
            transform.position = position;
            ChangeAnimationState(CAP_INTERACT);
        }
        else if (role == "canon")
        {
            position = canonTask;
            transform.position = position;
            ChangeAnimationState(CAP_INTERACT);
        }
        else if (role == "helm")
        {
            position = helmTask;
            transform.position = position;
            ChangeAnimationState(CAP_INTERACT);
        }
    }




    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Role") 
        {
            /*if (Input.GetKeyDown(KeyCode.E))
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
            }*/
        }
    }
}
