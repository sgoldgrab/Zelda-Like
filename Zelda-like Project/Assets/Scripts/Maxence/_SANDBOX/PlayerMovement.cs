using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;

    public float horizontal { get; private set; }
    public float vertical { get; private set; }

    public float lastX { get; private set; }
    public float lastY { get; private set; }

    public bool canMove { get; set; } = true;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (canMove)
        {
            transform.Translate(horizontal * playerSpeed * Time.deltaTime, vertical * playerSpeed * Time.deltaTime, 0);
        }

        if (horizontal != 0 || vertical != 0)
        {
            lastX = horizontal;
            lastY = vertical;
        }
    }
}
