using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameController game;
    private bool hit;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            Debug.Log("Player HIT");
            if (!hit)
            {
                //lives--;
                hit = true;
                game.InflictShipDamage(damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            hit = false;
            Debug.Log("Enemy MISSED");
        }
    }
}
