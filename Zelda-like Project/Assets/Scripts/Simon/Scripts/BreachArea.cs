using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreachArea : MonoBehaviour
{

    [SerializeField] public bool isActive = false;
    [SerializeField] private bool beingActivated = false;

    [SerializeField] private float timer = 6f;
    [SerializeField] private float activeTime = 6f;

    public GameObject breach;
    private BreachRift2 breachScript;

    private void Awake()
    {

        breachScript = breach.GetComponent<BreachRift2>();

    }

    private void Update()
    {
        if(!isActive)
        {
            timer -= Time.deltaTime;
            beingActivated = false;
        }

        if(isActive)
        {
            activeTime -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;

            isActive = true;
            timer = 18f;
        }

        if(activeTime <= 0)
        {
            GetComponent<SpriteRenderer>().color = Color.white;

            isActive = false;
            activeTime = 6f;
        }

        if(beingActivated)
        {
            breachScript.scoreUseless += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(isActive && other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = Color.blue;

            beingActivated = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if(other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = Color.white;

            beingActivated = false;
        }

    }

}
