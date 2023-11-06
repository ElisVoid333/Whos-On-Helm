using System.Collections;
using System.Collections.Generic;
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

    //Controller Variables
    public RoleController cleaner;
    public RoleController canon;
    public RoleController repair;
    public float repairRate = 15f;

    /*-- RANDOM EVENTS --*/
    //Random Rocks
    public RockController rock;



    // Start is called before the first frame update
    void Start()
    {
        total_happiness = MAX_HAPPINESS;
        total_health = MAX_HEALTH;

        //total_happiness = happinessMeter.fillAmount;
        //total_health = healthMeter.fillAmount;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cleaner.inRange)
        {
            total_happiness += 0.05f;
        }
        else
        {
            total_happiness -= 0.005f;
        }

        if (repair.inRange)
        {
            total_health += 10;
            repair.inRange = false;
        }

        if (canon.inRange)
        {
            canon.shooting = true;
        }
        else
        {
            canon.shooting = false;
        }

        if (rock.inflictDamage)
        {
            total_health -= 0.02f;
        }

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

       // Debug.Log(total_happiness / MAX_HAPPINESS);
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