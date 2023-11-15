using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 1f;
    public float rateOfUnhappy = 2f;
    public float spawnRate = 4f;
    public float timer;
    public float randomTime;

    private float x;
    private float y;
    private float x_start = -10;
    private float y_start_min = -2;
    private float y_start_max = 2;

    public int numOfPoops;
    protected GameObject[] poopList;
    public GameObject poopObject;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        numOfPoops = 0;
        randomTime = Random.Range(0.4f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            spawnBird();
            timer = 0f;
            randomTime = Random.Range(0.4f, 1f);
        }

        if (timer == randomTime)
        {
            Debug.Log("Im pooping!");
            numOfPoops++;
            spawnPoop(transform.position.x);
        }

        transform.Translate(0.02f, 0, 0);
    }

    private void spawnBird()
    {
        x = x_start;
        y = Random.Range(y_start_min, y_start_max);

        transform.position = new Vector3(x, y, 0);
    }


    private void spawnPoop(float current_position)
    {
        //Create New Poop Instance at bird location
        poopList[numOfPoops] = Instantiate(poopObject, new Vector3(current_position, y, 0), Quaternion.identity);
    }

}