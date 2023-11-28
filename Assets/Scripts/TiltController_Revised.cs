using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class TiltController_Revised : MonoBehaviour
{
    //Ship Tilt variables
    //private float tiltTimer;
    public float playerTiltForce = 1f;
    //public float tiltDirection;

    //Sin Wave Variables
    public float frequency = 2f;
    public float magnitude = 5f;

    //RigidBodies Variables
    //private Rigidbody2D rb;
    private Rigidbody2D player;
    private GameObject[] roles;
    private GameObject[] crew;

    //Positional Variables
    Vector3 shipStartPos;
    Vector3 playerStartPos;
    Vector3[] role_initial_positions;
    //Vector3[] role_movement_positions;
    Vector3[] crew_initial_positions;
    //Vector3[] crew_movement_positions;

    // Start is called before the first frame update
    void Start()
    {
        //Ship Tilt Timer Variables Initialize
        //tiltTimer = 0f;
        //tiltDirection = 0f;

        //Initialize Elements in scene
        //RigidBodies
        //rb = GetComponent<Rigidbody2D>(); //Ship itself
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //Gameobjects
        roles = GameObject.FindGameObjectsWithTag("Role");
        crew = GameObject.FindGameObjectsWithTag("Crew");

        //Initiliaze Starting Position
        shipStartPos = transform.position;

        playerStartPos = player.transform.position;

        role_initial_positions = new Vector3[roles.Length];
        role_initial_positions = setInitialPositions(roles, role_initial_positions);
        //role_movement_positions = new Vector3[roles.Length];
        //role_movement_positions = setInitialPositions(roles, role_movement_positions);

        crew_initial_positions = new Vector3[crew.Length];
        crew_initial_positions = setInitialPositions(crew, crew_initial_positions);
        //crew_movement_positions = new Vector3[crew.Length];
        //crew_movement_positions = setInitialPositions(crew, crew_movement_positions);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*rb.AddForce(new Vector2(0f, rb.transform.position.y) * Mathf.Sin(Time.time * frequency) * magnitude);
        player.AddForce(new Vector2(0f, player.transform.position.y) * Mathf.Sin(Time.time * frequency) * playerTiltForce);

        addForceForGameObjects(crew, frequency, magnitude);
        addForceForGameObjects(roles, frequency, magnitude);*/

        //Generate Sin Value
        float shipSinWave = generateSinValue(frequency, magnitude);
        float playerSinWave = generateSinValue(playerTiltForce, magnitude);

        //Ship Tilt
        //Debug.Log(shipStartPos * Mathf.Sin(Time.time * frequency) * magnitude);
        transform.position += shipStartPos * shipSinWave;

        //Player Tilt
        playerStartPos = player.transform.position;
        player.transform.position += playerStartPos * playerSinWave;

        //Crew Tilt
        crew = GameObject.FindGameObjectsWithTag("Crew");
        addForceForGameObjects(crew, playerSinWave);

        //Role Tilt
        addTiltToGameObjects(roles, role_initial_positions, shipSinWave);
    }
    
    //Generates SinWave value
    private float generateSinValue(float frequency, float magnitude)
    {
        float sinValue = Mathf.Sin(Time.time * frequency) * magnitude;
        return sinValue;
    }

    //Sets initial positions for roles
    private Vector3[] setInitialPositions(GameObject[] roles, Vector3[] role_initial_positions)
    {
        for (int i = 0; i < roles.Length; i++)
        {
            role_initial_positions[i] = roles[i].transform.position;
        }
        return role_initial_positions;
    }

    //Adds tilt to GameObjects by adding force
    public void addForceForGameObjects(GameObject[] array, float sinWave)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Rigidbody2D item = array[i].GetComponent<Rigidbody2D>();
            item.AddForce(new Vector2(0f, item.transform.position.y) * sinWave);
        }
    }

    //Adds tilt to GameObjects by manpulating position
    public void addTiltToGameObjects(GameObject[] array, Vector3[] startingPos, float sinWave)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Vector3 movement = startingPos[i];
            movement = startingPos[i] * sinWave;
            array[i].transform.position = new Vector3(startingPos[i].x, startingPos[i].y + movement.y, startingPos[i].z);
        }
    }

    //Function to move Crew around ship once role button pressed
    public void SetCrewPosition(GameObject crewMate)
    {
        for (int i = 0; i < crew.Length; i++)
        {
            if (crew[i] == crewMate)
            {
                crew_initial_positions[i] = crewMate.transform.position;
            }
            //crew[i].transform.position = new Vector3(crew_initial_positions[i].x, crew_initial_positions[i].y + (0.15f * moveSpeed), crew_initial_positions[i].z);
        }
    }
}
