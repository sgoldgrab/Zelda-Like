using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public bool isAtRange = false;

    public bool isActivated = false;

    private SpriteRenderer sprite;

    private GameObject player;

    private HealthPlayer playerHealth;
    private Movements playerMovements;

    private void Start()
    {

        player = GameObject.Find("Player");

        playerHealth = player.GetComponent<HealthPlayer>();

        playerMovements = player.GetComponent<Movements>();

        sprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {

        if (isAtRange && Input.GetKeyDown(KeyCode.A))
        {

            isActivated = !isActivated;

        }

        if (isActivated)
        {

            sprite.color = new Color(255, 0, 0);

            playerHealth.health += 2.5f * Time.deltaTime;

            playerMovements.speed = 1;

        }

        if(!isActivated)
        {

            sprite.color = new Color(255, 255, 255);

            playerMovements.speed = 3;

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Player"))
        {

            isAtRange = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            isAtRange = false;

        }

    }

}
