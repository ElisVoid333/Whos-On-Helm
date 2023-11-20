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

        occupant = ball;
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

            occupant = ball;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<PlayerController>().moveable == true)
            {
                instructions.gameObject.SetActive(true);
                interact = true;
            }

            //Debug.Log("Write Instructions");
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
            inRange = false;
            interact = false;
            instructions.gameObject.SetActive(false);


        } else if (collision.gameObject.tag == "Crew")
        {
            if (collision.gameObject == occupant.gameObject)
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
