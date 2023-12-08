using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource soundEffect; // Assign your sound effect clip here
    public float minInterval = 1.0f; // Minimum time between sound plays
    public float maxInterval = 5.0f; // Maximum time between sound plays

    private void Start()
    {
       
        Debug.Log("Started Creak");

      

        // Start the coroutine to play the sound at random intervals
        StartCoroutine(PlaySoundAtRandomIntervals());
    }

    private IEnumerator PlaySoundAtRandomIntervals()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));

         
                soundEffect.Play();
                Debug.Log("Played Creak");
            
        }
    }
}
