using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public int captain;

    private void Awake()
    {
        /*
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");

        if (objs.Length > 1)
        {
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }*/

        if (SceneManager.GetActiveScene().name == "07_LoseScene" || SceneManager.GetActiveScene().name == "06_WinScene")
        {
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }

        Debug.Log("Don't Destroy");
        DontDestroyOnLoad(this.gameObject);
    }
    public void SetCaptain(int i)
    {
        captain = i;
        Debug.Log(i);
    }

    public int GetCaptain()
    {
        Debug.Log("OLO: " + captain);
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
}
