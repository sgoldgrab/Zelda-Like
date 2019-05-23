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

    [SerializeField] private GameObject keyPrefab;

    [SerializeField] private GameObject altar2;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (tookHit) { timerTookHit -= Time.deltaTime; }

        if(timerTookHit <= 0)
        {
            timerTookHit = 4f;
            tookHit = false;
        }

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

        if(score >= 40)
        {
            Instantiate(keyPrefab, transform.position, transform.rotation);

            //altar2.GetComponent<Altar>().locked = false;

            Destroy(gameObject);
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
