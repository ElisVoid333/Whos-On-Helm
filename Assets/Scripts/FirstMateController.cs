using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMateController : MonoBehaviour
{
    private Vector3 position;

    //Player Animation
    public Animator animator;
    public GameController game;
    string currState;
    public string CREW_STATIC;
    public string CREW_INTERACT;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(0, 0, 0);

        //GameObject firsm8GameObject = GameObject.Find("firsm8");
        if (this.gameObject.name == "firsm8") {

            Debug.Log("Found Firstmate!");
            animator = this.GetComponent<Animator>();
            moveCrewmate("standby_1");
        }

        //GameObject secondm8GameObject = GameObject.Find("secondm8");
        if (this.gameObject.name == "secondm8")
        {

            Debug.Log("Found Secondmate!");
            animator = this.GetComponent<Animator>();
            moveCrewmate("standby_2");
        }

        if (this.gameObject.name == "thirdm8")
        {

            Debug.Log("Found Thirdmate!");
            animator = this.GetComponent<Animator>();
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


