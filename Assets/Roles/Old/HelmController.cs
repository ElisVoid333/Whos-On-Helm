using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelmController : MonoBehaviour
{
    public GameController gameCtrl;
    public float TimeLeft;
    public bool TimerOn;

    public Text TimerText;

    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = 240.0f; //4 minutes
        TimerOn = true;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                if (inRange)
                {
                    TimeLeft -= Time.deltaTime;
                }
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                gameCtrl.setScene(2);
            }
        }
        TimerText.text = "Countdown: " + TimeLeft.ToString("F0");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("IM DRIVING");
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Bye bye");
            inRange = false;
        }
    }
}



/*
    private void OnTriggerEvent2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("IM DRIVING");
            TimeLeft -= Time.deltaTime;
        }
    }*/ 


