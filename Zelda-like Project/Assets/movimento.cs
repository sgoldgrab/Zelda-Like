using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    private Vector2 movement;

    [SerializeField] private float movementSpeed = 2;

    private Rigidbody2D rb2D;

    private void Start()
    {
    
        rb2D = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

        GetInput();

        MoveCharacter(movement);

    }

    private void GetInput()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    public void MoveCharacter(Vector2 movementVector)
    {
        movementVector.Normalize();

        rb2D.velocity = movementVector * movementSpeed;

    }
}
