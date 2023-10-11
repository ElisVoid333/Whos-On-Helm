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

    // Start is called before the first frame update
    void Start()
    {
        inputX = 0; inputY = 0;
        speed = 0.005f;
        
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

    /*
    //Stop players from moving until role is complete
    private void RoleWorking()
    {
        speed = 0;
    }

    //Collisions to Do Roles
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);

        //Helm Role: Steering makes time go down faster
        if (collision.gameObject.tag == "Helm")
        {
            
        }
    }
    */
}
