using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    //Which captain has been chosen 
    static int captain;

    static float duration;
    static float happyVal;
    static float healthVal;
    static float score;
    static int kills;
    static int purse;
    static int fishWorth;
    static int fishesFished;

    static float Total_score;
    static int Total_count;
    static int Total_slipped;
    static float bank;

    static int trips_completed; // How many trips they have completed
    static int upgrade_status; // How many times they have upgraded 
    /*
     * 0 = small ship, 0 crewmates, base roles
     * 1 = small ship, 1 crewmates, base roles
     * 2 = medium ship, 1 crewmates, base roles + canon
     * 3 = medium ship, 2 crewmates, base roles + 2 canons
     * 4 = large ship, 2 crewmates, base roles + 2 canons + fishing
     * 5 = large ship, 3 crewmates, base roles + 2 canons + fishing + 2 enemys
     */

    //Crew mates
    static int firstM8_chosen = 1;
    static int secondM8_chosen = 2;
    static int thirdM8_chosen = 3;

    //Achievments
    static GameObject canonTrophy;
    static bool canonTrophyCompleted = false;
    static GameObject broomTrophy;
    static bool broomTrophyCompleted = false;
    static GameObject crownTrophy;
    static bool crownTrophyCompleted = false;
    static GameObject helmTrophy;
    static bool helmTrophyCompleted = false;
    static GameObject fishTrophy;
    static bool fishTrophyCompleted = false;


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");

        /*
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        */

        Debug.Log("Don't Destroy");
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        duration = 0f;
        happyVal = 0f;
        healthVal = 0f;
        fishWorth = 25;
        if (SceneManager.GetActiveScene().name == "08_achievements")
        {
            displayAchievements();
        }
    }


    public void SetCaptain(int i)
    {
        captain = i;
        Debug.Log("Set: " + i);
    }

    public int GetCaptain()
    {
        Debug.Log("Get: " + captain);
        return captain;
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
            int status = GetUpgrade();
            if (status == 0)
            {
                //SceneManager.LoadScene("01_Level_V1");
                SceneManager.LoadScene("03_Level_V1");
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

            }else
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

    public void LogPlayerData(float time, float happy, float health, int count, int loot, int fishCaught, int slippedOnPoop)
    {
        duration = time;
        happyVal = happy;
        healthVal = health;
        kills = count;
        purse = loot + (fishCaught * fishWorth);
        
        fishesFished += fishCaught;
        Total_slipped += slippedOnPoop;

        ProcessData();
    }

    public void ProcessData()
    {
        GameObject game = GameObject.Find("GameController");
        score = (120 - duration) + healthVal + happyVal;
        // total = duration, health, happy

        bank += (purse + happyVal/10f + healthVal/10f);

        trips_completed++;

        Total_score += score;
        Total_count += kills;

        calculateAchievements();
    }

    //Achievements 
    public void calculateAchievements()
    {
        if (Total_slipped >= 10)
        {
            broomTrophyCompleted = true;
        }
        if (Total_count >= 15)
        {
            canonTrophyCompleted = true;
        }
        if (duration >= 75f)
        {
            helmTrophyCompleted = true;
        }
        if (fishesFished >= 50)
        {
            fishTrophyCompleted = true;
        }
        if (bank >= 10000)
        {
            crownTrophyCompleted = true;
        }
    }

    public void displayAchievements()
    {
        //Get all trophies
        broomTrophy = GameObject.FindGameObjectWithTag("BroomTrophy");
        canonTrophy = GameObject.FindGameObjectWithTag("CanonTrophy");
        crownTrophy = GameObject.FindGameObjectWithTag("KingTrophy");
        helmTrophy = GameObject.FindGameObjectWithTag("HelmTrophy");
        fishTrophy = GameObject.FindGameObjectWithTag("FishTrophy");

        if (broomTrophyCompleted)
        {
            broomTrophy.SetActive(true);
        }
        else
        {
            broomTrophy.SetActive(false);
        }

        if (canonTrophyCompleted)
        {
            canonTrophy.SetActive(true);
        }
        else
        {
            canonTrophy.SetActive(false);
        }

        if (helmTrophyCompleted)
        {
            helmTrophy.SetActive(true);
        }
        else
        {
            helmTrophy.SetActive(false);
        }

        if (crownTrophyCompleted)
        {
            crownTrophy.SetActive(true);
        }
        else
        {
            crownTrophy.SetActive(false);
        }

        if (fishTrophyCompleted)
        {
            fishTrophy.SetActive(true);
        }
        else
        {
            fishTrophy.SetActive(false);
        }

    }

    public float GetPlayerFloat(string name)
    {
        //example Scoreboard asks for "string _duration_"

        // score for time taken: duration
        //score for total crew happiness at the end: happyVal
        //score for total ship health at the end: healthVal

        if (name != null)
        {
            if(name == "duration")
            {
                return duration;

            }
            if(name == "happiness")
            {
                return happyVal;
                
            }
            if(name == "health")
            {
                return healthVal;

            }
            if (name == "total")
            {
                return Total_score;

            }
            if (name == "bank")
            {
                return bank;

            }

        }
        return 0.0f;

    }

    public void SetPlayerFloat(string name, float value)
    {
        //example Scoreboard asks for "string _duration_"

        // score for time taken: duration
        //score for total crew happiness at the end: happyVal
        //score for total ship health at the end: healthVal

        if (name != null)
        {
            if (name == "duration")
            {
                duration = value;

            }
            if (name == "happiness")
            {
                happyVal = value;

            }
            if (name == "health")
            {
                healthVal = value;

            }
            if (name == "total")
            {
                Total_score = value;

            }
            if (name == "bank")
            {
                bank = value;

            }

        }

    }

    public int GetKillData()
    {

        //score for total navy kills: Total_count
        int navy = kills;
        return navy;

    }


    public void Kill()
    {
        Destroy(this.gameObject);
    }


    public void SetUpgrade(int status)
    {
        upgrade_status = status;
    }

    public void SetFirstM8(int skin)
    {
        firstM8_chosen = skin;
    }

    public void SetSecondM8(int skin)
    {
        secondM8_chosen = skin;
    }

    public void SetThirdM8(int skin)
    {
        thirdM8_chosen = skin;
    }


    public int GetUpgrade()
    {
        return upgrade_status;
    }

    public int GetFirstM8()
    {
        return firstM8_chosen;
    }

    public int GetSecondM8()
    {
        return secondM8_chosen;
    }

    public int GetThirdM8()
    {
        return thirdM8_chosen;
    }
}
