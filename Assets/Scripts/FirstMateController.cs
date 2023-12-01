using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMateController : MonoBehaviour
{
    private Vector2 position;

    //Player Animation
    public Animator animator;
    public GameController game;
    string currState;
    public string CREW_STATIC;
    public string CREW_INTERACT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject firsm8GameObject = GameObject.Find("firsm8");
        if (firsm8GameObject != null) { 
            animator = firsm8GameObject.GetComponent<Animator>();
            position = new Vector2(0, 0);
            moveCrewmate("stand");
        }

        GameObject secondm8GameObject = GameObject.Find("secondm8");
        if (secondm8GameObject != null)
        {
            animator = secondm8GameObject.GetComponent<Animator>();
            position = new Vector2(0, 0);
            moveCrewmate("standBy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            position = repairTask;
            transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            position = cleaningTask;
            transform.position = position;
        }*/
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
            position.x = position.x - 0.5f;
            transform.position = position;
            ChangeAnimationState(CREW_INTERACT);
        }
        else if (role == "stand")
        {
            position = GameObject.Find("StandBy_1").GetComponent<Transform>().position;
            transform.position = position;
            ChangeAnimationState(CREW_STATIC);
        }
        else if (role == "standBy")
        {
            position = GameObject.Find("StandBy_2").GetComponent<Transform>().position;
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


