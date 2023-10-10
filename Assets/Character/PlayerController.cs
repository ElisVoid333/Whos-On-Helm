using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    private float speed;
    private float inputX;
    private float inputY;

    //Time Variables

    //Role Variables
    

    // Start is called before the first frame update
    void Start()
    {
        inputX = 0; inputY = 0;
        speed = 0.05f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            inputY += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputY -= speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputX -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputX += speed;
        }


        Vector2 movement = new Vector2(inputX, inputY);
        //movement *= Time.deltaTime;
        transform.Translate(movement);
        inputX = 0;
        inputY = 0;
    }
}
