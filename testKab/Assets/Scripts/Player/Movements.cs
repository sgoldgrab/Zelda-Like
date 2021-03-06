﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2D;

    private Vector2 direction;

    public Vector2 lastInput;

    private HealthPlayer playerHealth;

    private void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();

        playerHealth = GetComponent<HealthPlayer>();

    }

    private void Update()
    {

        Inputs();   

    }

    private void FixedUpdate()
    {

        if (!playerHealth.isDead)
        {

            Movement();

        }

        direction = lastInput;

    }

    private void Inputs()
    {

        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

    }

    private void Movement()
    {

        rb2D.MovePosition(rb2D.position + direction * speed * Time.deltaTime);

    }

}
