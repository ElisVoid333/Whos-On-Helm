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
    public bool moveable;
    public bool occupied;
    public RoleController currentJob;

    //public Collider2D playableArea;

    private Vector2 position;

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
        speed = 1.5f;
        moveable = true;
        occupied = false;

        position = new Vector2(0, 0);

        //captainSelected = GameObject.FindGameObjectWithTag("DontDestroy").GetComponent<DontDestroy>().GetCaptain();
        captainSelected = 0;

        Debug.Log("The Capatain: " + captainSelected);


        GameObject captainGameObject = GameObject.Find("Captain");
        if (captainGameObject != null)
        {
            // Get the Animator component from the GameObject
            animator = captainGameObject.GetComponent<Animator>();
        }
    

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
            speed = 1.5f;
        }
        if (moveable == false)
        {
            speed = 0f;
        }

        if (moveable == true)
        {
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
        }
        


        //Vector2 movement = new Vector2(inputX, inputY);
        //movement *= Time.deltaTime;
        // transform.Translate(movement);


        // inputX = 0;
        //inputY = 0;
        float horizontalInput = inputX;
        float verticalInput = inputY;

        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
        //rb.drag = 500f;

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

        if (Input.GetKeyDown(KeyCode.E) && occupied)
        {
            if (moveable == false)
            {
                Debug.Log("Leaving role");
                moveable = true;
                occupied = false;
            }
        }

    }

    public void moveCaptain(string role)
    {
        if (role == "cleaner")
        {
            //position = cleaningTask;
            position = game.cleaner.GetComponent<Transform>().position;
            transform.position = position;
            ChangeAnimationState(CAP_INTERACT);
        }
        else if (role == "repair")
        {
            //position = repairTask;
            position = game.repair.GetComponent<Transform>().position;
            transform.position = position;
            ChangeAnimationState(CAP_INTERACT);
        }
        else if (role == "canon")
        {
            //position = canonTask;
            position = game.canon.GetComponent<Transform>().position;
            position.x = position.x - 0.5f;
            transform.position = position;
            ChangeAnimationState(CAP_INTERACT);
        }
        else if (role == "helm")
        {
            //position = helmTask;
            position = game.helm.GetComponent<Transform>().position;
            position.x = position.x - 0.7f;
            transform.position = position;
            ChangeAnimationState(CAP_INTERACT);
        }
    }

    public void SetMoveable(bool input)
    {
        moveable = input;
    }

    public void SetOccupied(RoleController job)
    {
        currentJob = job;

        occupied = true;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Role") 
        {
            
        }
    }
}
