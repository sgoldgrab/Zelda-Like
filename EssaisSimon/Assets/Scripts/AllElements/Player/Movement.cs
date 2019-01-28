using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private float speed = 4f;

    private Rigidbody2D rb2D;
    private Vector2 direction;

    public bool isDead = false;

    GameObject[] enemies;

    private void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        if (isDead)
        {

            Death();

        }

    }

    private void FixedUpdate()
    {

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        direction = new Vector2(inputX, inputY).normalized;

        if (!isDead)
        {

            rb2D.MovePosition(rb2D.position + direction * speed * Time.deltaTime);

        }

    }

    private void Death()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {

                Destroy(enemies[i]);

            }

            isDead = false;

        }
    }

}
