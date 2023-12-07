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
    public float TimeOriginal;
    public float TimeActual; //For Score
    public bool TimerOn;
    public Text TimerText;
    public float Score;

    //Fish
    public GameObject fishObj;
    private float fishTimer;
    private int fishCaught;

    //Controller Variables
    public RoleController cleaner;
    public RoleController canon;
    public RoleController repair;
    public RoleController fish;
    public float repairRate;
    public RoleController helm;
    public TiltController_Revised ship;

    /*-- RANDOM EVENTS --*/
    //Random Rocks
    public RockController rock;
    //Enemy
    public EnemyController enemy;
    //Bird
    public float poopRemoveTimer;
    public BirdController bird;
    public GameObject[] poopList;

    public GameObject objs; //temp val to hold PlayerData
    private bool PhysicsEnabled; //the case that determines if the scene is a playable one

    // Start is called before the first frame update
    void Start()
    {
        //Ship Variables
        total_happiness = MAX_HAPPINESS;
        total_health = MAX_HEALTH;

        objs = GameObject.FindGameObjectWithTag("DontDestroy");

        PhysicsEnabled = false;

        if (canon != null)
        {
            canon.y = canon.ball.transform.position.y;
            canon.x = canon.ball.transform.position.x;
        }

        //Fishing Initialize
        if (SceneManager.GetActiveScene().name == "03_Level_V1" || SceneManager.GetActiveScene().name == "03_Level_V2")
        { 
            fishObj.SetActive(false);
            fishCaught = 0;
            fishTimer = 0f;
        }

        //Countdown Timer Variables Initialize
        //TimeLeft = 240.0f; //4 minutes
        TimerOn = true;

        if(TimeLeft != 0f)
        {
            TimeOriginal = TimeLeft;
        }


        //Determine if the scene needs physics
        if (SceneManager.GetActiveScene().name == "01_Level_V1")
        {
            PhysicsEnabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "01_Level_V2")
        {
            PhysicsEnabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "02_Level_V1")
        {
            PhysicsEnabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "02_Level_V2")
        {
            PhysicsEnabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "03_Level_V1")
        {
            PhysicsEnabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "03_Level_V2")
        {
            PhysicsEnabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "tutorial")
        {
            PhysicsEnabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "01_Level")
        {
            PhysicsEnabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "03_Level")
        {
            PhysicsEnabled = true;
        }
        else
        {
            PhysicsEnabled = false;
        }
    }

    void Update()
    {
        if (PhysicsEnabled == true)
        {
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
                setScene(7);
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
                setScene(7);
            }


            //Timer Countdown
            if (TimerOn == false)
            {
                //LogPlayerData(float time, float happy, float health, int count, int loot)
                if (enemy != null)
                {
                    objs.GetComponent<PlayerData>().LogPlayerData(TimeActual, total_happiness, total_health, enemy.GetComponent<EnemyController>().attacks, 500, fishCaught);

                }else
                {
                    objs.GetComponent<PlayerData>().LogPlayerData(TimeActual, total_happiness, total_health, 0, 500, fishCaught);

                }
                Debug.Log("Wrote down the player score values for the level!");
                setScene(5);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        


        if (PhysicsEnabled == true)
        {
            PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            //Handle most of the Captain role behaviour
            if (canon != null)
            {
                if (canon.occupant == canon.ball)
                {

                    canon.shooting = false;
                }
            }

            if (player.occupied)
            {
                if (player.currentJob == cleaner)
                {
                    total_happiness += 0.05f;
                }
                else if (player.currentJob == repair)
                {
                    total_health += 0.07f;
                }
                else if (player.currentJob == canon)
                {
                    canon.shooting = true;
                }
                else if (player.currentJob == fish)
                {
                    total_happiness += 0.025f;
                    fishTimer += Time.deltaTime;
                    if (fishTimer >= 8.5f)
                    {
                        fishObj.SetActive(true);
                    }
                    if (fishTimer >= 10f)
                    {
                        fishTimer = 0f;
                        fishObj.SetActive(false);
                        fishCaught++;
                        Debug.Log(fishCaught);
                    }
                }

            }

            /*-- Roles --*/

            //Canon Role
            //Enable the Radial menu
            if( canon != null )
            {
                HandleCanonBall(canon);

                ShowMenu(0, canon);

                if (canon.crewInRange)
                {
                    canon.shooting = true;
                }
            }

            //Cleaning Role
            //Enable the Radial menu
            if (cleaner.crewInRange)
            {
                total_happiness += 0.05f;
            }
            ShowMenu(0, cleaner);


            //Fishing Role
            //Enable the Radial menu
            if(fish.crewInRange)
            {
                total_happiness += 0.025f;
                fishTimer += Time.deltaTime;
                if (fishTimer >= 8.5f)
                {

                }
                if (fishTimer >= 10f)
                {
                    fishTimer = 0f;
                    fishCaught++;
                    Debug.Log(fishCaught);
                }
            }
            ShowMenu(0, fish);


            //Minus Happiness
            total_happiness -= 0.01f;

            //Repair Role
            //Enable the Radial menu
            ShowMenu(0, repair);

            if (repair.crewInRange)
            {
                total_health += 0.07f;
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
            TimeActual += Time.deltaTime;

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
            //Rock
            if (rock.inflictDamage)
            {
                InflictShipDamage(2f);
            }

            //Bird

            //PoopCleaning
            if (cleaner.occupant != cleaner.ball)
            {
                poopList = GameObject.FindGameObjectsWithTag("Poop");
                //Debug.Log(poopList.ToString());
                if (poopList.Length > 0)
                {
                    poopRemoveTimer += Time.deltaTime;

                    if (poopRemoveTimer >= 3f)
                    {
                        Debug.Log("Cleaning Poop");
                        if (bird.numOfPoops > 0)
                        {
                            Destroy(poopList[poopList.Length - 1]);
                            bird.numOfPoops -= 1;
                            Debug.Log("Poop Removed");
                        }
                        poopRemoveTimer = 0f;
                    }
                }
            }

            
            TimerText.text = "Countdown: " + TimeLeft.ToString("F0");
            happinessMeter.fillAmount = total_happiness / MAX_HAPPINESS;
            healthMeter.fillAmount = total_health / MAX_HEALTH;

        }
    }

    public void InflictShipDamage(float damage)
    {
        total_health -= 0.02f * damage;
    }

    private void ShowMenu(int step, RoleController role)
    {
        if (canon != null)
        {
            //Debug.Log("Role: " + role);
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
        } else if (objs.GetComponent<PlayerData>().GetUpgrade() != 0)
        {
            //Debug.Log("Role: " + role);
            if (role.inRange)
            {
                role.transform.GetChild(step).gameObject.SetActive(true);
            }
            else
            {
                role.transform.GetChild(step).gameObject.SetActive(false);
                role.transform.GetChild(step).GetChild(1).GetChild(1).gameObject.SetActive(false);
            }
        }
        else
        {
            //Debug.Log("Role: " + role);
            if (role.inRange)
            {
                role.transform.GetChild(step).gameObject.SetActive(true);
            }
            else
            {
                role.transform.GetChild(step).gameObject.SetActive(false);
                
            }
        }

    }

    private void HandleCanonBall(RoleController canon)
    {

        if (canon.shooting)
        {
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
        }
        else
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

        if (i == 0)
        {
            GameObject objs = GameObject.FindGameObjectWithTag("DontDestroy");
            objs.GetComponent<PlayerData>().Kill();
            SceneManager.LoadScene("00_IntroScene");
        }
        else if (i == 1)
        {
            GameObject objs = GameObject.FindGameObjectWithTag("DontDestroy");
            int status = objs.GetComponent<PlayerData>().GetUpgrade();
            if (status == 0)
            {
                SceneManager.LoadScene("01_Level_V1");
                //SceneManager.LoadScene("03_Level");
            }
            else if (status == 1)
            {
                SceneManager.LoadScene("01_Level_V2");
            }
            else if (status == 2)
            {
                SceneManager.LoadScene("02_Level_V1");
            }
            else if (status == 3)
            {
                SceneManager.LoadScene("02_Level_V2");
            }
            else if (status == 4)
            {
                SceneManager.LoadScene("03_Level_V1");
            }
            else if (status == 5)
            {
                SceneManager.LoadScene("03_Level_V2");

            }
            else
            {
                SceneManager.LoadScene("06_WinScene");
            }
        }
        else if (i == 2)
        {
            SceneManager.LoadScene("02_Level");
        }
        else if (i == 3)
        {
            SceneManager.LoadScene("tutorial");

        }
        else if (i == 4)
        {
            SceneManager.LoadScene("04_BuyPhase");
        }
        else if (i == 5)
        {
            SceneManager.LoadScene("05_Score");
        }
        else if (i == 6)
        {
            SceneManager.LoadScene("06_WinScene");
        }
        else if (i == 7)
        {
            GameObject objs = GameObject.FindGameObjectWithTag("DontDestroy");
            objs.GetComponent<PlayerData>().Kill();
            SceneManager.LoadScene("07_LoseScene");
        }
        else if (i == 8)
        {
            SceneManager.LoadScene("08_Achievements");
        }

    }
}
