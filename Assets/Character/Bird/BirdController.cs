using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 1f;
    public float poopUnhappy = 10f;
    public float spawnRate = 10f; //Bird Spawning Timer
    public float timer; //Time.deltaTime
    public float timerPoop; //Time.deltaTime
    public float randomTime; //Random Range for spawning Poop

    private float x;
    private float y;
    private float x_start_min = -20;
    private float x_start_max = -10;
    private float y_start_min = -2;
    private float y_start_max = 2;

    public int numOfPoops;
    //protected GameObject[] poopList;
    public GameObject poopObject;
    public GameController gameController;

    //public CleanUpController happiness;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        numOfPoops = 0;
        randomTime = Random.Range(1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            spawnBird();
            timer = 0f;
            randomTime = Random.Range(2f, 6f);
        }

        if (transform.position.x >= -8)
        {
            if(transform.position.x >= 6)
            {
                timerPoop = 0f;
            }

            timerPoop += Time.deltaTime;
        }

        if (timerPoop >= randomTime)
        {
            Debug.Log("Im pooping!");
            numOfPoops++;
            spawnPoop(transform.position.x);
            randomTime = 100f;
        }

        //transform.Translate(0.01f, 0, 0);
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void spawnBird()
    {
        x = Random.Range(x_start_min, x_start_max);
        y = Random.Range(y_start_min, y_start_max);

        transform.position = new Vector3(x, y, 0);
    }


    private void spawnPoop(float current_position)
    {
        //Create New Poop Instance at bird location
        gameController.total_happiness -= poopUnhappy;
        Instantiate(poopObject, new Vector3(current_position, y, 0), Quaternion.identity);
    }

}
