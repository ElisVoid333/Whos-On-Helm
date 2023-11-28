using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltController_Revised : MonoBehaviour
{
    //Ship Tilt variables
    private float tiltTimer;
    public float tiltForce;
    public float tiltDirection;

    //RigidBodies Variables
    private Rigidbody2D rb;
    private Rigidbody2D player;
    private GameObject[] roles;
    private GameObject[] crew;

    // Start is called before the first frame update
    void Start()
    {
        //Ship Tilt Timer Variables Initialize
        //tiltTimer = 0f;
        //tiltDirection = 0f;

        //Initialize Elements in scene
        //RigidBodies
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //Gameobjects
        roles = GameObject.FindGameObjectsWithTag("Role");
        crew = GameObject.FindGameObjectsWithTag("Crew");
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }
}
