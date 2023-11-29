using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockController : MonoBehaviour
{
    public float speed;
    public float damageRate = 15f;
    private float x;
    private float y;
    private float lowerBound;
    public float spawnRate;

    public bool inflictDamage;
    RectTransform myRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        lowerBound = -10f;

        inflictDamage = false;

        myRectTransform = GetComponent<RectTransform>();
        myRectTransform.position += Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (myRectTransform.position.x < lowerBound * spawnRate)
        {
            x = 13.0f;
            y = Random.Range(-6.0f, 6.0f);
            Vector2 movement = new Vector2(x, y);
            transform.position = movement;
        }

        x = myRectTransform.position.x;
        transform.Translate(-speed * Time.deltaTime, 0, 0);
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


