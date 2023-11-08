using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    //Ship Tilt variables
    private float tiltTimer;
    //private float tiltStart;
    public float tiltDirection; // 0=Straight, 1=Left/Up, 2=Right/Down

    // Start is called before the first frame update
    void Start()
    {
        //Ship Tilt Timer Variables Initialize
        tiltTimer = 0f;
        tiltDirection = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Tilt Timing Controls
        tiltTimer += Time.deltaTime;

        if (tiltTimer > 4f)
        {
            tiltTimer = 0f;
        }
        Debug.Log(tiltTimer);
        tiltDirection = setTilt(tiltTimer);
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
        if (seconds > 1f)
        {
            phase = 1f;
        }
        //Neutral
        if (seconds > 2f)
        {
            phase = 0f;
        }
        //Tilt Right/Down
        if (seconds > 3f)
        {
            phase = 2f;
        }
        //Debug.Log(phase);
        return phase;
    }
}
