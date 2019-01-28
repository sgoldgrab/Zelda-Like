using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonController : MonoBehaviour
{

    private GameObject player;
    private Transform target;
    private Movement movement;

    private Rigidbody2D rb2D;

    [SerializeField]
    private float speed = 5f;

    private void Start()
    {

        player = GameObject.Find("Player");
        target = player.GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();

        movement = player.GetComponent<Movement>();

    }

    private void FixedUpdate()
    {

        rb2D.MovePosition(Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime));

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        /*if (other.tag == "Player")
        {

            movement.isDead = true;

        }*/

    }

}
