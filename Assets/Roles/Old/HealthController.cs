using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private const float MAX_HEALTH = 100f;
    public float repairRate = 15f;
    public Image SquareBar;

    public Collider2D ship;

    private bool inRange;
    private bool hit;

    public float total_health = 90f;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        total_health = MAX_HEALTH; 
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

        if (hit)
        {
            total_health -= 0.5f;
        }

        if (total_health > MAX_HEALTH)
        {
            total_health = MAX_HEALTH;
        }
        if (total_health < 0)
        {
            total_health = 0;
        }

        //Debug.Log(total_health / MAX_HEALTH); 
        SquareBar.fillAmount = total_health / MAX_HEALTH;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
        }

        if (collision.gameObject.tag == "Damage")
        {
            hit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }

        if (collision.gameObject.tag == "Damage")
        {
            hit = false;
        }
    }
}
