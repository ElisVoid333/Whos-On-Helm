using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMateController : MonoBehaviour
{
    private Vector2 position;
    private Vector2 cleaningTask;
    private Vector2 repairTask;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(0, 0);
        repairTask = new Vector2(-2.12f, -1.10f);
        cleaningTask = new Vector2(2.50f, 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            position = repairTask;
            transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            position = cleaningTask;
            transform.position = position;
        }
    }

    public void moveCrewmate(string role)
    {
        if(role == "cleaner")
        {
            position = cleaningTask;
            transform.position = position;
        }else if(role == "repair")
        {
            position = repairTask;
            transform.position = position;
        }
    }
}


