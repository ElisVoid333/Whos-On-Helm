using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Health Variables
    private const float MAX_HEALTH = 100f;
    public Image healthMeter;
    public float total_health;

    //Happiness Variables
    private const float MAX_HAPPINESS = 100f;
    public Image happinessMeter;
    public float total_happiness;

    //Helm Variables
    public float TimeLeft;
    public bool TimerOn;
    public Text TimerText;

    //Controller Variables
    public RoleController cleaner;
    public RoleController canon;
    public RoleController repair;
    public float repairRate = 15f;
    public RoleController helm;
    private int captain;

    /*-- RANDOM EVENTS --*/
    //Random Rocks
    public RockController rock;
    public EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        //Ship Variables
        total_happiness = MAX_HAPPINESS;
        total_health = MAX_HEALTH;

        canon.y = canon.ball.transform.position.y;
        canon.x = canon.ball.transform.position.x;

        //Countdown Timer Variables Initialize
        TimeLeft = 240.0f; //4 minutes
        TimerOn = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (SceneManager.GetActiveScene().name != "00_IntroScene" && SceneManager.GetActiveScene().name != "06_WinScene" && SceneManager.GetActiveScene().name != "07_LoseScene")
        {
            PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            //Handle most of the Captain role behaviour
            if(canon.occupant == canon.ball) {

                canon.shooting = false;
            }

            if (player.occupied)
            {
                if (player.currentJob == cleaner)
                {
                    total_happiness += 0.05f;
                }else if (player.currentJob == repair)
                {
                    total_health += 0.05f;
                }else if (player.currentJob == canon)
                {
                    canon.shooting = true;
                }
                
            }

            HandleCanonBall(canon);

            /*-- Roles --*/

            //Canon Role
            //Enable the Radial menu
            ShowMenu(0, canon);

            if (canon.crewInRange)
            {
                canon.shooting = true;
            }

            //Cleaning Role
            //Enable the Radial menu
            ShowMenu(0, cleaner);

            if (cleaner.crewInRange)
            {
                total_happiness += 0.05f;
            }

            total_happiness -= 0.01f;

            //Repair Role
            //Enable the Radial menu
            ShowMenu(0, repair);

            if (repair.crewInRange)
            {
                total_health += 0.05f;
                //repair.inRange = false;
            }

            //Helm Role
            if (TimerOn)
            {
                if (TimeLeft > 0f)
                {
                    TimeLeft -= Time.deltaTime;
                    if (player.occupied && player.currentJob == helm)
                    {
                        TimeLeft -= Time.deltaTime;
                    }
                }
                else
                {
                    TimeLeft = 0f;
                    TimerOn = false;
                }
            }

            //Enable the Radial menu on helm
            if (helm.inRange)
            {
                helm.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                helm.transform.GetChild(0).gameObject.SetActive(false);
            }

            /*-- Random Events --*/
            if (rock.inflictDamage)
            {
                InflictShipDamage(2f);
            }


            /*-- Outputable Variables --*/
            //Happiness
            if (total_happiness > MAX_HAPPINESS)
            {
                total_happiness = MAX_HAPPINESS;
            }
            else if (total_happiness < 0f)
            {
                total_happiness = 0f;
            }
            else if (total_happiness == 0f)
            {
                //Mutany
                setScene(3);
            }

            //Health
            if (total_health > MAX_HEALTH)
            {
                total_health = MAX_HEALTH;
            }
            else if (total_health < 0)
            {
                total_health = 0;
            }
            else if (total_health == 0)
            {
                //Sinks
                setScene(3);
            }

            //Timer Countdown
            if (TimerOn == false)
            {
                setScene(2);
            }
            TimerText.text = "Countdown: " + TimeLeft.ToString("F0");
            happinessMeter.fillAmount = total_happiness / MAX_HAPPINESS;
            healthMeter.fillAmount = total_health / MAX_HEALTH;

            if (!enemy.attacking)
            {
                if(TimeLeft % 5f < 0.011f)
                {
                    /*
                    Debug.Log("Random Event?");
                    float rnd = Random.Range(0f, 100.0f);
                    if (rnd < 95f && rnd > 90f)
                    {
                        Debug.Log("ATTACK!!!!");
                        enemy.SetTarget("attack");
                    }*/

                    //Debug.Log("ATTACK!!!!");
                    enemy.SetTarget("attack");

                }

            }
        }
    }

    private void InflictShipDamage(float damage)
    {
        total_health -= 0.02f * damage;
    }

    private void ShowMenu(int step, RoleController role) 
    {
        if (role.inRange)
        {
            role.transform.GetChild(step).gameObject.SetActive(true);
        }
        else
        {
            role.transform.GetChild(step).gameObject.SetActive(false);
            role.transform.GetChild(step).GetChild(1).GetChild(1).gameObject.SetActive(false);
            role.transform.GetChild(step).GetChild(1).GetChild(2).gameObject.SetActive(false);
        }
    }

    private void HandleCanonBall(RoleController canon)
    {

        if (canon.shooting) {
            canon.ball.SetActive(true);
            canon.y = canon.ball.transform.position.y;
            if (canon.ball.transform.position.y < -10f)
            {
                canon.y = canon.transform.position.y - 0.5f;
            }
            else
            {
                canon.y -= 0.05f;
                //Debug.Log("SHOOTING");
            }
        }else
        {
            //Debug.Log("NOT Shooting");
            canon.y = canon.transform.position.y - 0.5f;
            canon.ball.SetActive(false);
        }

        Vector2 movement = new Vector2(canon.x, canon.y);
        canon.ball.transform.position = movement;
    }

    public void setScene(int i)
    {
        if (i == 0) { 
            SceneManager.LoadScene("01_Level"); 
        }
        else if (i == 1)
        {
            SceneManager.LoadScene("00_IntroScene");
        }
        else if (i == 2)
        {
            SceneManager.LoadScene("06_WinScene");
        }
        else if (i == 3)
        {
            SceneManager.LoadScene("07_LoseScene");
        }
    }

    public void setCaptain(int num)
    {
        PlayerPrefs.SetInt("Captain", num);

    }

    public int getCaptain(string name)
    {
        captain = PlayerPrefs.GetInt(name);
        return captain;
    }
}