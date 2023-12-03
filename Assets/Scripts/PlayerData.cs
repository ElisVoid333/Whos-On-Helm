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
    static float Total_count;
    static float bank;

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
        Total_score = 0f;
        Total_count = 0f;
        bank = 0f;
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
    }

    public void LogPlayerData(float time, float happy, float health, int count, int loot)
    {
        duration = time;
        happyVal = happy;
        healthVal = health;
        kills = count;
        purse = loot;
    }

    public void ProcessData()
    {
        GameObject game = GameObject.Find("GameController");
        score = (game.GetComponent<GameController>().TimeLeft - duration) + healthVal + happyVal;

        bank = (score * 0.5f) + purse;

        Total_score =+ score;
        Total_count =+ kills;
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
