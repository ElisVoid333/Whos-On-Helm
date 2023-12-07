using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopController : MonoBehaviour
{
    public GameObject data;
    private int level;
    private int crewM8_1;
    private int crewM8_2;
    private int crewM8_3;
    private float bank;

    private int upgrade_cost;
    private int skin_cost;

    public TextMeshProUGUI bank_txt;
    public TextMeshProUGUI upgrade_txt;
    public TextMeshProUGUI skin_txt;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("DontDestroy");
        level = data.GetComponent<PlayerData>().GetUpgrade();
        bank = data.GetComponent<PlayerData>().GetPlayerFloat("bank");

        bank_txt.text = bank.ToString("0.00");

        if (level % 2 == 0)
        {
            upgrade_cost = 100;
        }else if (level % 2 == 1)
        {
            upgrade_cost = 50;
        }
        bank_txt.text = bank.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        bank = data.GetComponent<PlayerData>().GetPlayerFloat("bank");
    }

    public void UpgradeShip()
    {
        if (bank >= upgrade_cost)
        {
            level++;
            data.GetComponent<PlayerData>().SetUpgrade(level);
            bank -= upgrade_cost;
            data.GetComponent<PlayerData>().SetPlayerFloat("bank", bank);
        }
        
    }
}
