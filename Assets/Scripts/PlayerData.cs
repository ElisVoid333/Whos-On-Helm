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

    static float Total_score;
    static int Total_count;
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
    static int firstM8_chosen;
    static int secondM8_chosen;
    static int thirdM8_chosen;
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
        /*
        if (i == 0)
        {
            SceneManager.LoadScene("01_Level");
        }
        else if (i == 1)
        {
            Kill();
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
        else if (i == 4)
        {
            SceneManager.LoadScene("tutorial");
        }
        //// score, buy, acheivment
        else if (i == 5)
        {
            SceneManager.LoadScene("03_Score");
        }
        else if (i == 6)
        {
            SceneManager.LoadScene("04_BuyPhase");
        }
        else if (i == 7)
        {
            SceneManager.LoadScene("08_Achievements");
        }
        else if (i == 8)
        {
            SceneManager.LoadScene("02_Level");
        }*/

        if (i == 0)
        {
            GameObject objs = GameObject.FindGameObjectWithTag("DontDestroy");
            objs.GetComponent<PlayerData>().Kill();
            SceneManager.LoadScene("00_IntroScene");
        }
        else if (i == 1)
        {
            SceneManager.LoadScene("01_Level");
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

    public void LogPlayerData(float time, float happy, float health, int count, int loot)
    {
        duration = time;
        happyVal = happy;
        healthVal = health;
        kills = count;
        purse = loot;

        ProcessData();
    }

    public void ProcessData()
    {
        GameObject game = GameObject.Find("GameController");
        score = (120 - duration) + healthVal + happyVal;
        // total = duration, health, happy

        bank = (score * 0.5f) + purse;

        trips_completed++;

        Total_score += score;
        Total_count += kills;
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

    }

    public void SetSecondM8(int skin)
    {

    }

    public void SetThirdM8(int skin)
    {

    }


    public int GetUpgrade()
    {
        return upgrade_status;
    }

    public int GetFirstM8()
    {
        return 1;
    }

    public int GetSecondM8()
    {
        return 2;
    }

    public int GetThirdM8()
    {
        return 3;
    }
}
