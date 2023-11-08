using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltController : MonoBehaviour
{
    //Ship Tilt variables
    private float tiltTimer;
    //private float tiltStart;
    public float tiltDirection; // 0=Straight, 1=Left/Up, 2=Right/Down
    private GameObject[] roles;


    // Start is called before the first frame update
    void Start()
    {
        //Ship Tilt Timer Variables Initialize
        tiltTimer = 0f;
        tiltDirection = 0f;
        roles = GameObject.FindGameObjectsWithTag("Role");    
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

        //Move tilt Directions
        //Tilt Left/Up
        if (tiltDirection == 0f) {
            foreach (GameObject role in roles)
            {
                role.transform.position = new Vector3(role.transform.position.x, role.transform.position.y + 0.03f, role.transform.position.z);
            }
        }
        //Back To Neutral
        if (tiltDirection == 1f)
        {
            foreach (GameObject role in roles)
            {
                role.transform.position = new Vector3(role.transform.position.x, role.transform.position.y - 0.03f, role.transform.position.z); ;
            }
        }
        //Tilt Right/Down
        if (tiltDirection == 2f)
        {
            foreach (GameObject role in roles)
            {
                role.transform.position = new Vector3(role.transform.position.x, role.transform.position.y - 0.03f, role.transform.position.z); ;
            }
        }
        //Back To Neutral
        if (tiltDirection == 3f)
        {
            foreach (GameObject role in roles)
            {
                role.transform.position = new Vector3(role.transform.position.x, role.transform.position.y + 0.03f, role.transform.position.z); ;
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
}
