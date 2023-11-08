using System.Collections;
using System.Collections.Generic;
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

        //Countdown Timer Variables Initialize
        TimeLeft = 240.0f; //4 minutes
        TimerOn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*-- Roles --*/
        //Cleaning Role
        if (cleaner.inRange)
        {
            total_happiness += 0.05f;
            //cleaner.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            total_happiness -= 0.005f;
            /*cleaner.transform.GetChild(0).gameObject.SetActive(false);
            cleaner.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
            cleaner.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);*/
        }

        if (cleaner.crewInRange)
        {
            total_happiness += 0.05f;
        }
        else
        {
            total_happiness -= 0.005f;
        }

        //Repair Role
        if (repair.inRange)
        {
            repair.transform.GetChild(0).gameObject.SetActive(true);
        }
        else 
        {
            //repair.transform.GetChild(0).gameObject.SetActive(false);
            //repair.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
            //repair.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
        }

        if (repair.crewInRange)
        {
            total_health += 10;
            repair.inRange = false;
        }

        //Canon Role
        if (canon.inRange)
        {
            canon.shooting = true;
        }
        else
        {
            canon.shooting = false;
        }

        //Helm Role
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                if (helm.inRange)
                {
                    TimeLeft -= Time.deltaTime;
                }
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
            }
        }

        /*-- Random Events --*/
        if (rock.inflictDamage)
        {
            total_health -= 0.02f;
        }

        /*-- Outputable Variables --*/
        //Happiness
        if (total_happiness > MAX_HAPPINESS)
        {
            total_happiness = MAX_HAPPINESS;
        }else if (total_happiness < 0f)
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
        // Debug.Log(total_happiness / MAX_HAPPINESS);
        TimerText.text = "Countdown: " + TimeLeft.ToString("F0");
        happinessMeter.fillAmount = total_happiness / MAX_HAPPINESS;
        healthMeter.fillAmount = total_health / MAX_HEALTH;
    }

    public void setScene(int i)
    {
        if (i == 0) { 
            SceneManager.LoadScene("01_Level1"); 
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
}
