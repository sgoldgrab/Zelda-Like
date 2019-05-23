using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreachArea : MonoBehaviour
{

    [SerializeField] private bool isActive = false;
    [SerializeField] private bool beingActivated = false;

    [SerializeField] private float timer = 6f;
    [SerializeField] private float activeTime = 6f;

    public GameObject breach;
    private BreachRift2 breachScript;

    private SpriteRenderer sprite;

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
            isActive = true;
            timer = 18f;
        }

        if(activeTime <= 0)
        {
            isActive = false;
            activeTime = 6f;
        }

        if(beingActivated)
        {
            breachScript.score += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(isActive && other.CompareTag("Player"))
        {
            beingActivated = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if(other.CompareTag("Player"))
        {
            beingActivated = false;
        }

    }

}
