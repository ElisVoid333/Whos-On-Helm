using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_controller : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;

    public float waitTime = 2f;
    void Start()
    {
        StartCoroutine(PopUps());
    }

    // Update is called once per frame
    void Update()
    {
        //if(popUpIndex == 0)
        //{
        //    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        //    {
        //        Debug.Log("wasd accepted");
        //        popUpIndex++;
        //    }
        //}
       


    }

    public IEnumerator PopUps()
    {
        Debug.Log("Popsups started");
        for (int popUpIndex = 0; popUpIndex < popUps.Length; popUpIndex++)
        {
          if(popUpIndex == 1)
            {
                popUps[popUpIndex].SetActive(true);
                yield return new WaitForSeconds(5f);
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                Debug.Log("Next popup");
            }
            if (popUpIndex == 2)
            {
                popUps[popUpIndex].SetActive(true);
                yield return new WaitForSeconds(5f);
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
                Debug.Log("Next popup");
            }
            if (popUpIndex == 3)
            {
                popUps[popUpIndex].SetActive(true);
                yield return new WaitForSeconds(5f);
           
                Debug.Log("wait for helm");
            }










        }
        //~~~~~~~~~
    }
}
