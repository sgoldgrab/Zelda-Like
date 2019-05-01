using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreachRift1 : MonoBehaviour
{
    private float score = 0;

    private float timer = 12f;
    private bool isActive = false;

    private void Update()
    {
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
        if (other.CompareTag("")) { score += 15; }
    }
}
