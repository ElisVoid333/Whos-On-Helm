using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    //Role Variables
    public bool inRange;
    private bool interact;
    public bool crewInRange;
    public GameObject ball;
    public bool shooting;
    public TextMeshProUGUI instructions;

    private float y;



    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        interact = false;
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

        if (Input.GetKeyDown(KeyCode.E) && interact)
        {
            //Debug.Log("EEEEEEEEEEEEEEEEEEEEEEEEE");
            //inRange = true;
            if (inRange)
            {
                inRange = false;
            }
            else
            {
                inRange = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<PlayerController>().moveable == true)
            {
                instructions.gameObject.SetActive(true);
                interact = true;
            }

            //Debug.Log("Write Instructions");
            //Debug.Log("Interact: " + interact);
            //Debug.Log("inRange: " + inRange);
            
        }
        else if (collision.gameObject.tag == "Crew")
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
            interact = false;
            instructions.gameObject.SetActive(false);
        } else if (collision.gameObject.tag == "Crew")
        {
            crewInRange = false;
        }
    }

    public void setRange(bool setter)
    {
        inRange = setter;
    }
}
