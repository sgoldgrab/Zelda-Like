using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreachController : MonoBehaviour
{

    public GameObject angel;
    public GameObject demon;

    private int minX = -2;
    private int minY = -2;
    private int maxX = 2;
    private int maxY = 2;

    private float spawnRateDemon = 8;
    private float timerDemon = 8;

    private float spawnRateAngel = 8;
    private float timerAngel = 12;

    public GameObject player;
    private Movement movement;

    private void Start()
    {
        movement = player.GetComponent<Movement>();
    }

    private void Update ()
    {
        if(!movement.isDead)
        {
            timerDemon -= Time.deltaTime;
            timerAngel -= Time.deltaTime;
        }
        
        if(timerDemon <= 0)
        {
            Instantiate(demon, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
            timerDemon = spawnRateDemon;
        }

        if(timerAngel <= 0)
        {
            Instantiate(angel, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
            timerAngel = spawnRateAngel;
        }
    }

}
