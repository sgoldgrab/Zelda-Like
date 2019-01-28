using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{

    private GameObject player;
    private Movement movement;

    public float boltTimer = 1.5f;

    private void Start()
    {
        player = GameObject.Find("Player");
        movement = player.GetComponent<Movement>();
    }

    private void Update()
    {
        boltTimer -= Time.deltaTime;

        if(boltTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            movement.isDead = true;
        }

        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }

}
