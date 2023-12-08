using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopController : MonoBehaviour
{
    public PlayerData data;
    private int level;
    private int crewM8_1;
    private int crewM8_1_temp;
    private int crewM8_2;
    private int crewM8_2_temp;
    private int crewM8_3;
    private int crewM8_3_temp;
    private int captain_chosen;
    private float bank = 0.00f;

    private int upgrade_cost;
    private int skin_cost;

    public TextMeshProUGUI bank_txt;
    public TextMeshProUGUI upgrade_txt;
    public TextMeshProUGUI skin_txt;

    public SpriteRenderer crew_1;
    public SpriteRenderer crew_2;
    public SpriteRenderer crew_3;
    public Sprite crew_sprite1;
    public Sprite crew_sprite2;
    public Sprite crew_sprite3;

    public SpriteRenderer captain_1;
    public SpriteRenderer captain_2;
    public SpriteRenderer captain_3;
    public Sprite maleStatic;
    public Sprite femaleStatic;
    public Sprite neutralStatic;

    public SpriteRenderer upgrade_icon01;
    public SpriteRenderer upgrade_icon02;
    public SpriteRenderer upgrade_icon03;
    public SpriteRenderer upgrade_icon04;
    public SpriteRenderer upgrade_icon05;
    public SpriteRenderer upgrade_icon06;
    public SpriteRenderer upgrade_icon07;
    public SpriteRenderer upgrade_icon08;
    public SpriteRenderer upgrade_icon09;
    public SpriteRenderer upgrade_icon10;
    public SpriteRenderer upgrade_icon11;
    public SpriteRenderer upgrade_icon12;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("DontDestroy").GetComponent<PlayerData>();

        captain_chosen = data.GetCaptain();

        if (captain_chosen == 0)
        {
            captain_1.sprite = maleStatic;
            captain_2.sprite = maleStatic;
            captain_3.sprite = maleStatic;
        }
        else if (captain_chosen == 1)
        {
            captain_1.sprite = femaleStatic;
            captain_2.sprite = femaleStatic;
            captain_3.sprite = femaleStatic;
        }
        else if (captain_chosen == 2)
        {
            captain_1.sprite = neutralStatic;
            captain_2.sprite = neutralStatic;
            captain_3.sprite = neutralStatic;
        }

        level = data.GetUpgrade();
        bank = data.GetPlayerFloat("bank");
        crewM8_1 = data.GetFirstM8();
        crewM8_1_temp = crewM8_1;
        crewM8_2 = data.GetSecondM8();
        crewM8_2_temp = crewM8_2;
        crewM8_3 = data.GetThirdM8();
        crewM8_3_temp = crewM8_3;

        bank_txt.text = bank.ToString("0.00");

        SetCost(level);
        SetSkinCost();

        SetupUpgrades(level);
    }

    // Update is called once per frame
    void Update()
    {
        bank = data.GetPlayerFloat("bank");
        bank_txt.text = bank.ToString("0.00");

        SetupUpgrades(level);
        SetCost(level);

        //SetSkinCost();
    }

    public void ResetButton(int crewMate)
    {
        if (crewMate == 1)
        {
            crew_1.sprite = crew_sprite1;
        }
        else if (crewMate == 2)
        {
            crew_2.sprite = crew_sprite2;
        }
        else if (crewMate == 3)
        {
            crew_3.sprite = crew_sprite3;
        }

        //skin_cost = 0;
    }

    public void SetCrew1(int skin)
    {
        crewM8_1_temp = skin;
        if (skin == 1)
        {
            crew_1.sprite = crew_sprite1;
        }
        else if (skin == 2)
        {
            crew_1.sprite = crew_sprite2;
        }
        else if (skin == 3)
        {
            crew_1.sprite = crew_sprite3;
        }
    }

    public void SetCrew2(int skin)
    {
        crewM8_2_temp = skin;
        if (skin == 1)
        {
            crew_2.sprite = crew_sprite1;
        }
        else if (skin == 2)
        {
            crew_2.sprite = crew_sprite2;
        }
        else if (skin == 3)
        {
            crew_2.sprite = crew_sprite3;
        }
    }

    public void SetCrew3(int skin)
    {
        crewM8_3_temp = skin;
        if (skin == 1)
        {
            crew_3.sprite = crew_sprite1;
        }
        else if (skin == 2)
        {
            crew_3.sprite = crew_sprite2;
        }
        else if (skin == 3)
        {
            crew_3.sprite = crew_sprite3;
        }
    }

    public void UpgradeShip()
    {
        if (bank >= upgrade_cost && level < 5)
        {
            level++;
            data.SetUpgrade(level);
            bank -= upgrade_cost;
            data.SetPlayerFloat("bank", bank);
        }
        
    }

    public void CustomizeCrew()
    {
        crewM8_1 = crewM8_1_temp;
        crewM8_2 = crewM8_2_temp;
        crewM8_3 = crewM8_3_temp;

        if (bank >= skin_cost && level < 5)
        {
            data.SetFirstM8(crewM8_1);
            data.SetSecondM8(crewM8_2);
            data.SetThirdM8(crewM8_3);

            bank -= skin_cost;
            data.SetPlayerFloat("bank", bank);
        }

    }

    public void SetCost(int status)
    {
        if (status % 2 == 0)
        {
            upgrade_cost = 500;
        }
        else if (status % 2 == 1)
        {
            upgrade_cost = 1000;
        }
        upgrade_txt.text = upgrade_cost.ToString("0.00");
    }

    public void SetSkinCost()
    {
        if (crewM8_1 != crewM8_1_temp)
        {
            skin_cost += 150;
        }
        if (crewM8_2 != crewM8_2_temp)
        {
            skin_cost += 150;
        }
        if (crewM8_3 != crewM8_3_temp)
        {
            skin_cost += 150;
        }
        skin_txt.text = skin_cost.ToString("0.00");
    }

    public void SetupUpgrades(int status)
    {
        //Debug.Log("Upgrade Status : " + status);

        if (status == 0)
        {
            upgrade_icon01.color = Color.white;
            upgrade_icon02.color = Color.white;
            upgrade_icon03.color = Color.black;
            upgrade_icon04.color = Color.black;
            upgrade_icon05.color = Color.black;
            upgrade_icon06.color = Color.black;
            upgrade_icon07.color = Color.black;
            upgrade_icon08.color = Color.black;
            upgrade_icon09.color = Color.black;
            upgrade_icon10.color = Color.black;
            upgrade_icon11.color = Color.black;
            upgrade_icon12.color = Color.black;
        }
        else if (status == 1)
        {
            upgrade_icon01.color = Color.white;
            upgrade_icon02.color = Color.white;
            upgrade_icon03.color = Color.white;
            upgrade_icon04.color = Color.black;
            upgrade_icon05.color = Color.black;
            upgrade_icon06.color = Color.black;
            upgrade_icon07.color = Color.black;
            upgrade_icon08.color = Color.black;
            upgrade_icon09.color = Color.black;
            upgrade_icon10.color = Color.black;
            upgrade_icon11.color = Color.black;
            upgrade_icon12.color = Color.black;
        }
        else if (status == 2)
        {
            upgrade_icon01.color = Color.white;
            upgrade_icon02.color = Color.white;
            upgrade_icon03.color = Color.white;
            upgrade_icon04.color = Color.white;
            upgrade_icon05.color = Color.white;
            upgrade_icon06.color = Color.white;
            upgrade_icon07.color = Color.black;
            upgrade_icon08.color = Color.black;
            upgrade_icon09.color = Color.black;
            upgrade_icon10.color = Color.black;
            upgrade_icon11.color = Color.black;
            upgrade_icon12.color = Color.black;
        }
        else if (status == 3)
        {
            upgrade_icon01.color = Color.white;
            upgrade_icon02.color = Color.white;
            upgrade_icon03.color = Color.white;
            upgrade_icon04.color = Color.white;
            upgrade_icon05.color = Color.white;
            upgrade_icon06.color = Color.white;
            upgrade_icon07.color = Color.white;
            upgrade_icon08.color = Color.black;
            upgrade_icon09.color = Color.black;
            upgrade_icon10.color = Color.black;
            upgrade_icon11.color = Color.black;
            upgrade_icon12.color = Color.black;

        }
        else if (status == 4)
        {
            upgrade_icon01.color = Color.white;
            upgrade_icon02.color = Color.white;
            upgrade_icon03.color = Color.white;
            upgrade_icon04.color = Color.white;
            upgrade_icon05.color = Color.white;
            upgrade_icon06.color = Color.white;
            upgrade_icon07.color = Color.white;
            upgrade_icon08.color = Color.white;
            upgrade_icon09.color = Color.white;
            upgrade_icon10.color = Color.white;
            upgrade_icon11.color = Color.white;
            upgrade_icon12.color = Color.black;
        }
        else if (status == 4)
        {
            upgrade_icon01.color = Color.white;
            upgrade_icon02.color = Color.white;
            upgrade_icon03.color = Color.white;
            upgrade_icon04.color = Color.white;
            upgrade_icon05.color = Color.white;
            upgrade_icon06.color = Color.white;
            upgrade_icon07.color = Color.white;
            upgrade_icon08.color = Color.white;
            upgrade_icon09.color = Color.white;
            upgrade_icon10.color = Color.white;
            upgrade_icon11.color = Color.white;
            upgrade_icon12.color = Color.white;
        }
    }
}
