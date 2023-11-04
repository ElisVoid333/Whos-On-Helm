using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockController : MonoBehaviour
{
    public float speed;
    public float damageRate = 15f;
    public HealthController health;
    private float x;
    private float y;
    private float lowerBound;

    public bool inflictDamage;
    RectTransform myRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        lowerBound = -600;

        inflictDamage = false;

        myRectTransform = GetComponent<RectTransform>();
        myRectTransform.localPosition += Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (myRectTransform.localPosition.x < lowerBound)
        {
            x = 10.0f;
            y = Random.Range(-6.0f, 6.0f);
        }
        else
        {
            x -= speed;
        }

        Vector2 movement = new Vector2(x, y);
        transform.position = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Ship")
        {
            //Debug.Log("Grabbing Mop");
            inflictDamage = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            //Debug.Log("All cleaned up");
            inflictDamage = false;
        }

    }
}


