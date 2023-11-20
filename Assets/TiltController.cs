using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class TiltController : MonoBehaviour
{
    //Ship Tilt variables
    private float tiltTimer;
    public float tiltForce = 50f;
    //private float tiltStart;
    public float tiltDirection; // 0=Straight, 1=Left/Up, 2=Right/Down
    private GameObject[] roles;
    private GameObject player;
    public Rigidbody2D rb;
    Vector3[] initial_positions;

    public float moveSpeed = 5f;
    public bool canMove;
    public string boundaryTag = "Border"; // Use the tag you assigned to your colliders.

    // Start is called before the first frame update
    void Start()
    {
        //Ship Tilt Timer Variables Initialize
        tiltTimer = 0f;
        tiltDirection = 0f;

        player = GameObject.FindGameObjectWithTag("Player");
        //rb = player.GetComponent<Rigidbody2D>();

        roles = GameObject.FindGameObjectsWithTag("Role");

        initial_positions = new Vector3[roles.Length];
        initial_positions = setInitialPositions(roles, initial_positions);
    }

    /*
    void Update()
    {
        
        canMove = true;
        // Get input for player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the player's new position
        Vector3 newPosition = player.transform.position + new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // Check if the new position is inside or overlapping any colliders with the "border" tag
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.1f);


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
            player.transform.position = newPosition;
        }

        canMove = true;
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        //Tilt Timing Controls
        tiltTimer += Time.deltaTime;

        if (tiltTimer > 4f)
        {
            tiltTimer = 0f;
        }
        //Debug.Log(tiltTimer);
        tiltDirection = setTilt(tiltTimer);
        //Debug.Log(initial_positions);

        //Player Move tilt Directions
        //Tilt Left/Up
        if (tiltDirection == 1f)
        {
            //player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.01f, player.transform.position.z);
            rb.AddForce(new Vector2(0f, tiltForce));
            //print("Tilt Up");
        }
        //Tilt Right/Down
        if (tiltDirection == 3f)
        {
            //player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.01f, player.transform.position.z);
            rb.AddForce(new Vector2(0f, -tiltForce));
            //print("Tilt Down");
        }


        // Roles tilt positions
        //Neutral
        if (tiltDirection == 0f) {
            for (int i = 0; i < roles.Length; i++)
            {
                roles[i].transform.position = new Vector3(initial_positions[i].x, initial_positions[i].y, initial_positions[i].z);
            }
        }
        //Tilt Left/Up
        if (tiltDirection == 1f)
        {
            for (int i = 0; i < roles.Length; i++)
            {
                roles[i].transform.position = new Vector3(initial_positions[i].x, initial_positions[i].y + 0.2f, initial_positions[i].z);
            }
        }
        //Neutral
        if (tiltDirection == 2f)
        {
            for (int i = 0; i < roles.Length; i++)
            {
                roles[i].transform.position = new Vector3(initial_positions[i].x, initial_positions[i].y, initial_positions[i].z);
            }
        }
        //Tilt Right/Down
        if (tiltDirection == 3f)
        {
            for (int i = 0; i < roles.Length; i++)
            {
                roles[i].transform.position = new Vector3(initial_positions[i].x, initial_positions[i].y - 0.2f, initial_positions[i].z);
            }
        }

       
    }

    protected float setTilt(float seconds)
    {
        float phase = 0f;
        //Neutral
        if (seconds >= 0f)
        {
            phase = 0f;
        }
        //Tilt Left/Up
        if (seconds >= 1f)
        {
            phase = 1f;
        }
        //Neutral
        if (seconds >= 2f)
        {
            phase = 2f;
        }
        //Tilt Right/Down
        if (seconds >= 3f)
        {
            phase = 3f;
        }
        //Debug.Log(phase);
        return phase;
    }

    private Vector3[] setInitialPositions(GameObject[] roles, Vector3[] initial_positions)
    {
        for (int i = 0; i < roles.Length; i++)
        {
            initial_positions[i] = roles[i].transform.position;
        }
        return initial_positions;
    }
}
