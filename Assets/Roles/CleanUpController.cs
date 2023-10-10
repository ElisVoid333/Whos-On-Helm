using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanUpController : MonoBehaviour
{
    private const float MAX_HAPPINESS = 100f;
    public float messyRate = 0.03f;
    public float cleaningRate = 0.1f;
    public Image SquareBar;

    private bool inRange;

    private float total_happiness = 100f;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        SquareBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            total_happiness += MAX_HAPPINESS * cleaningRate;
        }
        if (inRange == false)
        {
            total_happiness -= MAX_HAPPINESS * messyRate;
        }
        SquareBar.fillAmount = total_happiness / MAX_HAPPINESS;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Grabbing Mop");
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("All cleaned up");
            inRange = false;
        }
    }
}
