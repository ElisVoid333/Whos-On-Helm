using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_controller : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;

    public float waitTime = 5f;

    public int didWalk = 0;
   
    void Start()
    {
        StartCoroutine(PopUps());
    }

    // Update is called once per frame
    void Update()
    {
        //if (didWalk == 0)
        //{
        //    if (Input.GetKey(KeyCode.F))
        //    {
        //        Debug.Log("wasd accepted");
        //        didWalk = 1;
        //        popUpIndex++;
        //        Debug.Log("Walked, moving on" + popUpIndex);

        //    }
        //}

        //Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)


    }

    public IEnumerator PopUps()
    {
        Debug.Log("Popsups started");

        if (popUpIndex == 0)
        {
            popUps[popUpIndex].SetActive(true);
            yield return new WaitForSeconds(5f);
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            Debug.Log("Next popup");
        }
        if (popUpIndex == 1)
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
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            Debug.Log("Next popup");
        }
        if (popUpIndex == 4)
        {
            popUps[popUpIndex].SetActive(true);
            yield return new WaitForSeconds(5f);
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            Debug.Log("Next popup");
        }
        if (popUpIndex == 5)
        {
            popUps[popUpIndex].SetActive(true);
            yield return new WaitForSeconds(5f);
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            Debug.Log("Next popup");
        }

        if (popUpIndex == 6)
        {
            popUps[popUpIndex].SetActive(true);
            yield return new WaitForSeconds(5f);
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            Debug.Log("Next popup");
        }

        if (popUpIndex == 7)
        {
            popUps[popUpIndex].SetActive(true);
            yield return new WaitForSeconds(5f);
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            Debug.Log("Next popup");
        }

        if (popUpIndex == 8)
        {
            popUps[popUpIndex].SetActive(true);
            yield return new WaitForSeconds(5f);
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            Debug.Log("Next popup");
        }

        if (popUpIndex == 9)
        {
            popUps[popUpIndex].SetActive(true);
            yield return new WaitForSeconds(5f);
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            Debug.Log("Next popup");
        }

        if (popUpIndex == 10)
        {
            popUps[popUpIndex].SetActive(true);
            yield return new WaitForSeconds(5f);

            Debug.Log("Next popup");
        }







        //~~~~~~~~~
    }
}
