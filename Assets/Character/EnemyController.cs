using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Player's Ships Health
    public HealthController health;

    private float lives;
    private float damage = 20f;
    private float timeBetweenShots = 6f;
    private MeshRenderer ship;

    private float respawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<MeshRenderer>();
        ship.enabled = false;
        lives = 3f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
