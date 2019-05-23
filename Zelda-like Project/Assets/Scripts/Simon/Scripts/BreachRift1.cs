using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreachRift1 : MonoBehaviour
{
    private float score = 0;

    private float timerTookHit = 2f;

    private float timer = 12f;
    private bool isActive = false;

    private bool tookHit = false;

    private void Update()
    {
        if(tookHit) { timerTookHit -= Time.deltaTime; }

        if(timerTookHit <= 0)
        {
            timerTookHit = 4f;
            tookHit = false;
        }

        timer -= Time.deltaTime;

        if(timer <= 0 && !isActive)
        {
            isActive = true;
            timer = 12f;
        }

        if(timer <= 0 && isActive)
        {
            isActive = false;
            timer = 12f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("")) //METTRE LE BON TAG
        {
            if(!tookHit)
            {
                score += 15;
                tookHit = true;
            }

            if(tookHit)
            {
                score += 15;
                isActive = false;
            }
        }
    }
}
