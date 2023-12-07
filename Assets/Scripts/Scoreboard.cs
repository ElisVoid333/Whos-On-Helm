using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public GameObject playerdata;
    // LogPlayerData(float time, float happy, float health, int count, int loot)
    //ProcessData()
    //GetKillData()
    //GetPlayerFloat(string name)

    public TextMeshProUGUI label1;
    public TextMeshProUGUI label2;
    public TextMeshProUGUI label3;
    public TextMeshProUGUI label4;
    public TextMeshProUGUI label5;




    // Start is called before the first frame update
    void Start()
    {
     
        playerdata = GameObject.FindGameObjectWithTag("DontDestroy");

        float time = playerdata.GetComponent<PlayerData>().GetPlayerFloat("duration");
        float happy = playerdata.GetComponent<PlayerData>().GetPlayerFloat("happiness");
        float health = playerdata.GetComponent<PlayerData>().GetPlayerFloat("health");
        int navy = playerdata.GetComponent<PlayerData>().GetKillData();
        float total = playerdata.GetComponent<PlayerData>().GetPlayerFloat("total");

        label1.text = time.ToString("0.00");
        label2.text = happy.ToString("0.00");
        label3.text = health.ToString("0.00");
        label4.text = navy.ToString();
        label5.text = total.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
