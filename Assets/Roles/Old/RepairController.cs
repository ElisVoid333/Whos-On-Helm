using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairController : MonoBehaviour
{

    public bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Grabbing Mop");
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("All cleaned up");
            inRange = false;
        }
    }
}
