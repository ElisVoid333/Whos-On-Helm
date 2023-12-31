using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_controller : MonoBehaviour
{
    public GameObject[] popUps;  // Assign your popups in the inspector
    public GameObject popupBG;
    private int popUpIndex = 1;


    public AudioSource bell;



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

                bell.Play();
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
            popUps[popUpIndex].SetActive(false);
            popupBG.SetActive(false);

            // If there are no more popups

        }
        }

}

