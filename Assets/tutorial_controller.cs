using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_controller : MonoBehaviour
{
    public GameObject[] popUps;  // Assign your popups in the inspector
    private int popUpIndex = 1;
    private bool waitForSpacebar = true;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Check for spacebar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Trigger the next popup
            ShowNextPopup();
        }




    }

    void ShowNextPopup()
    {
        if (popUpIndex < popUps.Length)
        {
            // Disable the previous popup
            if (popUpIndex > 0)
            {
                popUps[popUpIndex - 1].SetActive(false);
            }

            // Enable the current popup
            popUps[popUpIndex].SetActive(true);

            // Increment index for the next popup
            popUpIndex++;
            Debug.Log("Next popup");
        }
        else
        {
            Debug.Log("No more popups");
            popUpIndex = 0;
            // If there are no more popups, you can perform any other actions here
        }
    }

        //public IEnumerator ShowNextPopup()
        //{
        //    Debug.Log("Popups started");

        //    waitForSpacebar = false; // Disable further spacebar input until the current popup is complete

        //    if (popUpIndex < popUps.Length)
        //    {
        //        popUps[popUpIndex].SetActive(true);

        //        Debug.Log("Next popup");
        //    }
        //    else
        //    {
        //        Debug.Log("No more popups");
        //        // If there are no more popups, you can perform any other actions here
        //    }

        //    waitForSpacebar = true;

        //    //Debug.Log("Popsups started");

        //    //if (popUpIndex == 0)
        //    //{
        //    //    popUps[popUpIndex].SetActive(true);
        //    //    yield return new WaitForSeconds(5f);
        //    //    popUps[popUpIndex].SetActive(false);
        //    //    popUpIndex++;
        //    //    Debug.Log("Next popup");
        //    //}
        //    //if (popUpIndex == 1)
        //    //{
        //    //    popUps[popUpIndex].SetActive(true);
        //    //    yield return new WaitForSeconds(5f);
        //    //    popUps[popUpIndex].SetActive(false);
        //    //    popUpIndex++;
        //    //    Debug.Log("Next popup");
        //    //}
        //    //if (popUpIndex == 2)
        //    //{
        //    //    popUps[popUpIndex].SetActive(true);
        //    //    yield return new WaitForSeconds(5f);
        //    //    popUps[popUpIndex].SetActive(false);
        //    //    popUpIndex++;
        //    //    Debug.Log("Next popup");

        //    //}
        //    //if (popUpIndex == 3)
        //    //{
        //    //    popUps[popUpIndex].SetActive(true);
        //    //    yield return new WaitForSeconds(5f);
        //    //    popUps[popUpIndex].SetActive(false);
        //    //    popUpIndex++;
        //    //    Debug.Log("Next popup");
        //    //}
        //    //if (popUpIndex == 4)
        //    //{
        //    //    popUps[popUpIndex].SetActive(true);
        //    //    yield return new WaitForSeconds(5f);
        //    //    popUps[popUpIndex].SetActive(false);
        //    //    popUpIndex++;
        //    //    Debug.Log("Next popup");
        //    //}
        //    //if (popUpIndex == 5)
        //    //{
        //    //    popUps[popUpIndex].SetActive(true);
        //    //    yield return new WaitForSeconds(5f);
        //    //    popUps[popUpIndex].SetActive(false);
        //    //    popUpIndex++;
        //    //    Debug.Log("Next popup");
        //    //}

        //    //if (popUpIndex == 6)
        //    //{
        //    //    popUps[popUpIndex].SetActive(true);
        //    //    yield return new WaitForSeconds(5f);
        //    //    popUps[popUpIndex].SetActive(false);
        //    //    popUpIndex++;
        //    //    Debug.Log("Next popup");
        //    //}

        //    //if (popUpIndex == 7)
        //    //{
        //    //    popUps[popUpIndex].SetActive(true);
        //    //    yield return new WaitForSeconds(5f);
        //    //    popUps[popUpIndex].SetActive(false);
        //    //    popUpIndex++;
        //    //    Debug.Log("Next popup");
        //    //}

        //    //if (popUpIndex == 8)
        //    //{
        //    //    popUps[popUpIndex].SetActive(true);
        //    //    yield return new WaitForSeconds(5f);
        //    //    popUps[popUpIndex].SetActive(false);
        //    //    popUpIndex++;
        //    //    Debug.Log("Next popup");
        //    //}

        //    //if (popUpIndex == 9)
        //    //{
        //    //    popUps[popUpIndex].SetActive(true);
        //    //    yield return new WaitForSeconds(5f);
        //    //    popUps[popUpIndex].SetActive(false);
        //    //    popUpIndex++;
        //    //    Debug.Log("Next popup");
        //    //}

        //    //if (popUpIndex == 10)
        //    //{
        //    //    popUps[popUpIndex].SetActive(true);
        //    //    yield return new WaitForSeconds(5f);

        //    //    Debug.Log("Next popup");
        //    //}







        //    //~~~~~~~~~
        //}
    }
