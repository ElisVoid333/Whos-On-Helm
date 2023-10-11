using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private const float MAX_HEALTH = 100f;
    public float repairRate = 15f;
    public Image SquareBar;

    private bool inRange;

    private float total_health = 10f;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        //SquareBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            total_health += repairRate;
            inRange = false;
        }

        if (total_health > MAX_HEALTH)
        {
            total_health = MAX_HEALTH;
        }
        if (total_health < 0)
        {
            total_health = 0;
        }

        Debug.Log(total_health / MAX_HEALTH); 
        SquareBar.fillAmount = total_health / MAX_HEALTH;
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
