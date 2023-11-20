using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float shipSpeed;

    private Vector2 targetPos;
    private Vector2 currentPos;
    private Vector2 initialPos;

    private Vector2 attackPos;
    private Vector2 fleePos;
    private Vector2 ballPos;

    private int lives;
    private float damage = 20f;
    private float timeBetweenShots = 6f;
    public GameObject ship;

    public bool attacking;
    public bool hit;
    public bool shooting;
    public bool fire;
    private GameObject ball;

    private float respawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        //ship.enabled = false;
        initialPos = new Vector2(-13.3f, -5.3f);
        currentPos = initialPos;
        targetPos = currentPos;

        attackPos = new Vector2(0.58f, -5.3f);
        fleePos = new Vector2(13f, -5.3f);

        attacking = false;
        shooting = false;
        fire = false;
        lives = 3;

        ball = ship.transform.GetChild(0).gameObject;

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
            }else if (currentPos.x >= fleePos.x)
            {
                ResetShip();
            }
        }

        if (attacking)
        {
            shooting = true;
            
        }
        HandleEnemyCanonBall(ball);

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

    private void HandleEnemyCanonBall(GameObject canonball)
    {
        //Debug.Log("Enemy CanonBall");
        if (shooting)
        {
            if (!fire)
            {
                Debug.Log("FIRE!!!");
                ballPos.x = ship.transform.position.x + 2f;
                fire = true;
            }
            //Debug.Log("Enemy CanonBall");
            canonball.SetActive(true);
            ballPos.y = canonball.transform.position.y;
            if (canonball.transform.localPosition.y > 50f)
            {
                ballPos.y = initialPos.y + 0.5f;
                fire = false;
            }
            else
            {
                ballPos.y += 0.025f;
                //Debug.Log("SHOOTING");
            }
        }
        else
        {
            //Debug.Log("NOT Shooting");
            ballPos.y = transform.position.y + 1f;
            ballPos.x = ship.transform.position.x + 2f;

            fire = false;

            canonball.SetActive(false);
        }
        
        Vector2 movement = new Vector2(ballPos.x, ballPos.y);
        Debug.Log("Move : " + movement);
        canonball.transform.position = movement;
    }

    private void ResetShip()
    {
        currentPos.x = initialPos.x;
        ship.transform.position = new Vector3(currentPos.x, currentPos.y, 0f);
        targetPos = initialPos;
        attacking = false;
        lives = 3;
        shooting = false;
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
