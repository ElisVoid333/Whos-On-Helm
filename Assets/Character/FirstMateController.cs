using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMateController : MonoBehaviour
{
    private Vector2 position;
    private Vector2 cleaningTask;
    private Vector2 repairTask;
    private Vector2 canonTask;
    private Vector2 helmTask;

    //Player Animation
    public Animator animator;
    string currState;
    public string CREW_STATIC;
    public string CREW_INTERACT;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(0, 0);
        repairTask = new Vector2(5.1f, 0.90f);
        cleaningTask = new Vector2(-0.88f, 1.66f);
        canonTask = new Vector2(2.41f, -1.20f);
        helmTask = new Vector2(-6.14f, 0.16f);
        ChangeAnimationState(CREW_STATIC);
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
        if(role == "cleaner")
        {
            position = cleaningTask;
            transform.position = position;
            ChangeAnimationState(CREW_INTERACT);
        }
        else if(role == "repair")
        {
            position = repairTask;
            transform.position = position;
            ChangeAnimationState(CREW_INTERACT);
        }
        else if (role == "canon")
        {
            position = canonTask;
            transform.position = position;
            ChangeAnimationState(CREW_INTERACT);
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


