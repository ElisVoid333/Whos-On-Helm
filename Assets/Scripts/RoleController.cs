using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    public Sprite baseRole;
    public Sprite highlightRole;

    public float y;
    public float x;



    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        crewInRange = false;
        interact = false;
        shooting = false;

        occupant = ball;
    }

    // Update is called once per frame
    void Update()
    {
        if (occupant != ball)
        {
            this.GetComponent<SpriteRenderer>().sprite = highlightRole;
        } else
        {
            this.GetComponent<SpriteRenderer>().sprite = baseRole;
        }

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

            occupant = ball;
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
        if (collision.gameObject.tag == "Crew")
        {
            //crewInRange = true;
            Debug.Log("Caught Crewmate");
            //Debug.Log("Collision: " + collision.gameObject.name + "Occupant: " + occupant.gameObject.name);
            if (collision.gameObject.name == occupant.gameObject.name)
            {
                crewInRange = true;
                //Debug.Log("Occupant: " + occupant.gameObject.name);
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

        }
        if (collision.gameObject.tag == "Crew")
        {
            
            if (collision.gameObject.name == occupant.gameObject.name)
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
        setRange(false);
    }
}
