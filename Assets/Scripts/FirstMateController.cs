using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMateController : MonoBehaviour
{
    private Vector3 position;

    //Player Animation
    public Animator animator;
    public RuntimeAnimatorController controller1;
    public RuntimeAnimatorController controller2;
    public RuntimeAnimatorController controller3;
    public Sprite crewSprite_1;
    public Sprite crewSprite_2;
    public Sprite crewSprite_3;

    public GameController game;
    string currState;
    public string CREW_STATIC;
    public string CREW_INTERACT;

    private int chosenM8_1;
    private int chosenM8_2;
    private int chosenM8_3;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(0, 0, 0);

        chosenM8_1 = game.objs.GetComponent<PlayerData>().GetFirstM8();
        chosenM8_2 = game.objs.GetComponent<PlayerData>().GetSecondM8();
        chosenM8_3 = game.objs.GetComponent<PlayerData>().GetThirdM8();


        //GameObject firsm8GameObject = GameObject.Find("firsm8");
        if (this.gameObject.name == "firsm8") {

            Debug.Log("Found Firstmate! First");
            animator = this.GetComponent<Animator>();
            SpriteRenderer spriteR = this.GetComponent<SpriteRenderer>();

            if (chosenM8_1 == 1)
            {
                Debug.Log("Found Firstmate!");
                spriteR.sprite = crewSprite_1;
                this.animator.runtimeAnimatorController = controller1;
                this.CREW_INTERACT = "crewmate1_interact";
                this.CREW_STATIC = "crewmate1_idle";
            }
            else if (chosenM8_1 == 2)
            {
                Debug.Log("Found Firstmate! Second");
                spriteR.sprite = crewSprite_2;
                this.animator.runtimeAnimatorController = controller2;
                this.CREW_INTERACT = "crewmate2_interact";
                this.CREW_STATIC = "crewmate2_idle";
            }
            else if (chosenM8_1 == 3)
            {
                Debug.Log("Found Firstmate! Drunk");
                spriteR.sprite = crewSprite_3;
                this.animator.runtimeAnimatorController = controller3;
                this.CREW_INTERACT = "crewmate3_interact";
                this.CREW_STATIC = "crewmate3_idle";
            }

            moveCrewmate("standby_1");
        }

        //GameObject secondm8GameObject = GameObject.Find("secondm8");
        if (this.gameObject.name == "secondm8")
        {

            Debug.Log("Found Secondmate!");
            animator = this.GetComponent<Animator>();
            SpriteRenderer spriteR = this.GetComponent<SpriteRenderer>();

            if (chosenM8_2 == 1)
            {
                spriteR.sprite = crewSprite_1;
                this.CREW_INTERACT = "crewmate1_interact";
                this.CREW_STATIC = "crewmate1_idle";
            }
            else if (chosenM8_2 == 2)
            {
                spriteR.sprite = crewSprite_2;
                this.CREW_INTERACT = "crewmate2_interact";
                this.CREW_STATIC = "crewmate2_idle";
            }
            else if (chosenM8_2 == 3)
            {
                spriteR.sprite = crewSprite_3;
                this.CREW_INTERACT = "crewmate3_interact";
                this.CREW_STATIC = "crewmate3_idle";
            }

            moveCrewmate("standby_2");
        }

        if (this.gameObject.name == "thirdm8")
        {

            Debug.Log("Found Thirdmate!");
            animator = this.GetComponent<Animator>();
            SpriteRenderer spriteR = this.GetComponent<SpriteRenderer>();

            if (chosenM8_3 == 1)
            {
                spriteR.sprite = crewSprite_1;
                this.CREW_INTERACT = "crewmate1_interact";
                this.CREW_STATIC = "crewmate1_idle";
            }
            else if (chosenM8_3 == 2)
            {
                spriteR.sprite = crewSprite_2;
                this.CREW_INTERACT = "crewmate2_interact";
                this.CREW_STATIC = "crewmate2_idle";
            }
            else if (chosenM8_3 == 3)
            {
                spriteR.sprite = crewSprite_3;
                this.CREW_INTERACT = "crewmate3_interact";
                this.CREW_STATIC = "crewmate3_idle";
            }

            moveCrewmate("standby_3");
        }
    }


    public void moveCrewmate(string role)
    {
        if (role == "cleaner")
        {
            position = game.cleaner.GetComponent<Transform>().position;
            position.y = position.y + 0.5f;
            transform.position = position;
            ChangeAnimationState(CREW_INTERACT);
        }
        else if (role == "repair")
        {
            position = game.repair.GetComponent<Transform>().position;
            position.y = position.y + 0.5f;
            transform.position = position;
            ChangeAnimationState(CREW_INTERACT);
        }
        else if (role == "canon")
        {
            position = game.canon.GetComponent<Transform>().position;
            position.x = position.x + 0.5f;
            transform.position = position;
            ChangeAnimationState(CREW_INTERACT);
        }
        else if (role == "fish")
        {
            position = game.fish.GetComponent<Transform>().position;
            transform.position = position;
            ChangeAnimationState(CREW_INTERACT);
        }
        else if (role == "standby_1")
        {
            position = GameObject.Find("Standby_1").GetComponent<Transform>().position;
            transform.position = position;
            ChangeAnimationState(CREW_STATIC);
        }
        else if (role == "standby_2")
        {
            position = GameObject.Find("Standby_2").GetComponent<Transform>().position;
            transform.position = position;
            ChangeAnimationState(CREW_STATIC);
        }
        else if (role == "standby_3")
        {
            position = GameObject.Find("Standby_3").GetComponent<Transform>().position;
            transform.position = position;
            ChangeAnimationState(CREW_STATIC);
        }
    }

    private void ChangeAnimationState(string newState)
    {
        if (newState == currState)
        {
            return;
        }

        animator.Play(newState);
        currState = newState;
    }

}


