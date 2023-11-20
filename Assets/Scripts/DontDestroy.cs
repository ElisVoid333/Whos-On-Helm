using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private int captain;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "06_WinScene" || SceneManager.GetActiveScene().name == "07_LoseScene")
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
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
    }

    public void SetCaptain(int i)
    {
        captain = i;
    }

    public int GetCaptain()
    {
        return captain;
    }
}
