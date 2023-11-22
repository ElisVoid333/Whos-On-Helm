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
    public GameObject occupant;
    public GameObject ball;
    public bool shooting;
    public GameObject instructions;

    public float y;
    public float x;



    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        interact = false;
        shooting = false;

        occupant = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && interact)
        {
            if (inRange)
            {
                inRange = false;
                
            }
            else
            {
                inRange = true;
                
            }

            occupant = null;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<PlayerController>().moveable == true)
            {
                if (instructions != null)
                {
                    instructions.gameObject.SetActive(true);
                }
                
                interact = true;
                //Debug.Log("Write Instructions");
            }

            //Debug.Log("Write Instructions");
        }
        else if (collision.gameObject.tag == "Crew")
        {
            if (collision == occupant)
            {
                crewInRange = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
            interact = false;

            collision.GetComponent<PlayerController>().occupied = false;
            
            if (instructions != null)
            {
                instructions.gameObject.SetActive(false);
            }

        } else if (collision.gameObject.tag == "Crew")
        {
            if (collision == occupant)
            {
                crewInRange = false;

                occupant = ball;
            }
        }
    }

    public void setRange(bool setter)
    {
        inRange = setter;
    }

    public void SetOccupant(GameObject worker)
    {
        occupant = worker;

    }
}
