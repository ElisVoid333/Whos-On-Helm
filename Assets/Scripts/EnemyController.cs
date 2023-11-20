using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Player's Ships Health
    //public HealthController health;
    //public Rigidbody2D shipRb;
    public float shipSpeed;

    private Vector2 targetPos;
    private Vector2 currentPos;

    private Vector2 attackPos;
    private Vector2 fleePos;

    private int lives;
    private float damage = 20f;
    private float timeBetweenShots = 6f;
    public GameObject ship;

    public bool attacking;
    public bool hit;

    private float respawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        //ship.enabled = false;
        Vector2 initialPos = new Vector2(-13.3f, -5.3f);
        currentPos = initialPos;
        targetPos = currentPos;

        attackPos = new Vector2(0.58f, -5.3f);
        fleePos = new Vector2(13f, -5.3f);

        attacking = false;
        lives = 3;

    }

    // Update is called once per frame
    void Update()
    {
        currentPos.x = transform.position.x;
        currentPos.y = transform.position.y;

        if (currentPos != targetPos)
        {
            if (targetPos.x > currentPos.x)
            {
                //Debug.Log("Target x: " + targetPos.x + "  Current x: " + currentPos.x);

                currentPos.x = currentPos.x + shipSpeed;
                ship.transform.position = new Vector3(currentPos.x, currentPos.y, 0f);
            }
        }

        if (lives == 0)
        {
            SetTarget("flee");

        }
    }

    public void SetTarget(string target)
    {
        if (target == "attack")
        {
            attacking = true;
            targetPos = attackPos;
        }else if (target == "flee")
        {
            targetPos = fleePos;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Canonball")
        {
            Debug.Log("Enemy HIT");
            if (!hit)
            {
                lives--;
                hit = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Canonball")
        {
            hit = false;
            Debug.Log("Enemy MISSED");
        }
    }

}
