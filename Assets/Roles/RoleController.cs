using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    //Canon Role Variables
    public bool inRange;
    public bool crewInRange;
    public GameObject ball;
    public bool shooting;
    public TextMeshProUGUI instructions;

    private float y;
    //private float x;



    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting)
        {
            ball.SetActive(true);
            if (ball.transform.localPosition.y > 10)
            {
                y = 0;
            }
            else
            {
                y += 0.005f;
            }

            Vector2 movement = new Vector2(0, y);
            ball.transform.position = movement;
        }
        else
        {
            ball.SetActive(false);
            y = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Grabbing Mop");
            instructions.gameObject.SetActive(true);
            inRange = true;
            /*if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(collision.gameObject.tag);
                inRange = true;
            }*/
        } else if (collision.gameObject.tag == "Crew")
        {
            crewInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("All cleaned up");
            inRange = false;
            instructions.gameObject.SetActive(false);
        } else if (collision.gameObject.tag == "Crew")
        {
            crewInRange = false;
        }
    }
}
