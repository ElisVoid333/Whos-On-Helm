using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class TiltController_Revised : MonoBehaviour
{
    //Ship Tilt variables
    //private float tiltTimer;
    public float playerTiltForce = 0.5f;
    private float crewTiltForce = 0.5f;
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

        //Ship Tilt
        //Debug.Log(shipStartPos * Mathf.Sin(Time.time * frequency) * magnitude);
        transform.position += shipStartPos * Mathf.Sin(Time.time * frequency) * magnitude;

        //Player Tilt

        //Crew Tilt
        crew = GameObject.FindGameObjectsWithTag("Crew");
        addTiltToGameObjects(crew, crew_initial_positions);

        //Role Tilt
        addTiltToGameObjects(roles, role_initial_positions);
    }
    

    private Vector3[] setInitialPositions(GameObject[] roles, Vector3[] role_initial_positions)
    {
        for (int i = 0; i < roles.Length; i++)
        {
            role_initial_positions[i] = roles[i].transform.position;
        }
        return role_initial_positions;
    }

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

    public void addForceForGameObjects(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Rigidbody2D item = array[i].GetComponent<Rigidbody2D>();
            item.AddForce(new Vector2(0f, item.transform.position.y) * Mathf.Sin(Time.time * frequency) * magnitude * playerTiltForce);
        }
    }

    public void addTiltToGameObjects(GameObject[] array, Vector3[] startingPos)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Vector3 movement = startingPos[i];
            movement = startingPos[i] * Mathf.Sin(Time.time * frequency) * magnitude;
            array[i].transform.position = new Vector3(startingPos[i].x, startingPos[i].y + movement.y, startingPos[i].z);
        }
    }

}
