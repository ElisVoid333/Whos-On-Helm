using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopController : MonoBehaviour
{
    public GameObject data;
    private int level;
    private float bank;

    private int upgrade_cost;

    public TextMeshProUGUI bank_txt;
    public TextMeshProUGUI label2;
    public TextMeshProUGUI label3;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("DontDestroy");
        level = data.GetComponent<PlayerData>().GetUpgrade();
        bank = data.GetComponent<PlayerData>().GetPlayerFloat("bank");

        bank_txt.text = bank.ToString();

        if (level % 2 == 0)
        {
            upgrade_cost = 100;
        }else if (level % 2 == 1)
        {
            upgrade_cost = 50;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bank = data.GetComponent<PlayerData>().GetPlayerFloat("bank");
    }

    public void UpgradeShip()
    {
        level++;
        data.GetComponent<PlayerData>().SetUpgrade(level);
        bank -= upgrade_cost;
        data.GetComponent<PlayerData>().SetPlayerFloat("bank", bank);
    }
}
