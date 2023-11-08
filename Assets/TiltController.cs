using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class TiltController : MonoBehaviour
{
    //Ship Tilt variables
    private float tiltTimer;
    //private float tiltStart;
    public float tiltDirection; // 0=Straight, 1=Left/Up, 2=Right/Down
    private GameObject[] roles;
    private GameObject player;
    Vector3[] initial_positions;

    // Start is called before the first frame update
    void Start()
    {
        //Ship Tilt Timer Variables Initialize
        tiltTimer = 0f;
        tiltDirection = 0f;

        player = GameObject.FindGameObjectWithTag("Player");
        roles = GameObject.FindGameObjectsWithTag("Role");

        initial_positions = new Vector3[roles.Length];
        initial_positions = setInitialPositions(roles, initial_positions);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Tilt Timing Controls
        tiltTimer += Time.deltaTime;

        if (tiltTimer > 6f)
        {
            tiltTimer = 0f;
        }
        Debug.Log(tiltTimer);
        tiltDirection = setTilt(tiltTimer);

        //Debug.Log(initial_positions);
        //Player Move tilt Directions
        //Tilt Left/Up
        if (tiltDirection == 0f)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.03f, player.transform.position.z);
        }
        //Back To Neutral
        if (tiltDirection == 1f)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.03f, player.transform.position.z);
        }
        //Tilt Right/Down
        if (tiltDirection == 2f)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.03f, player.transform.position.z);
        }
        //Back To Neutral
        if (tiltDirection == 3f)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.03f, player.transform.position.z);
        }

        // Roles tilt positions
        //Tilt Left/Up
        if (tiltDirection == 0f) {
            for (int i = 0; i < roles.Length; i++)
            {
                roles[i].transform.position = new Vector3(initial_positions[i].x, initial_positions[i].y + 0.1f, initial_positions[i].z);
            }
        }
        //Back To Neutral
        if (tiltDirection == 1f)
        {
            for (int i = 0; i < roles.Length; i++)
            {
                roles[i].transform.position = new Vector3(initial_positions[i].x, initial_positions[i].y - 0.1f, initial_positions[i].z);
            }
        }
        //Tilt Right/Down
        if (tiltDirection == 2f)
        {
            for (int i = 0; i < roles.Length; i++)
            {
                roles[i].transform.position = new Vector3(initial_positions[i].x, initial_positions[i].y - 0.1f, initial_positions[i].z);
            }
        }
        //Back To Neutral
        if (tiltDirection == 3f)
        {
            for (int i = 0; i < roles.Length; i++)
            {
                roles[i].transform.position = new Vector3(initial_positions[i].x, initial_positions[i].y + 0.1f, initial_positions[i].z);
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
        if (seconds > 1.5f)
        {
            phase = 1f;
        }
        //Neutral
        if (seconds > 3f)
        {
            phase = 2f;
        }
        //Tilt Right/Down
        if (seconds > 4.5f)
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
