using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private bool dashMove;

    [SerializeField] private float dashRange;
    [SerializeField] private float dashDuration;
    private float duration;
    [SerializeField] private float dashSpeed;

    private Vector2 dashDirection;

    [SerializeField] private float dashCooldown;
    private float cooldown;

    private PlayerMovement playerMovement;
    private PlayerState playerState;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerState = GetComponent<PlayerState>();
    }

    void Update()
    {
        DashDirection();

        if (Input.GetButtonDown("Dash") && cooldown <= 0.0f)
        {
            dashMove = true;
            duration = dashDuration;
            playerMovement.canMove = false;

            foreach (Collider2D col in playerState.playerColliders) col.enabled = false;
        }

        DashMove();

        cooldown -= Time.deltaTime;
    }

    void DashMove()
    {
        if (dashMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, dashDirection, dashSpeed * Time.deltaTime);

            if (duration <= 0.0f)
            {
                dashMove = false;
                playerMovement.canMove = true;

                cooldown = dashCooldown;

                foreach (Collider2D col in playerState.playerColliders) col.enabled = true;
            }

            else
            {
                duration -= Time.deltaTime;
            }
        }
    }

    void DashDirection()
    {
        if (playerMovement.lastX != 0 || playerMovement.lastY != 0)
        {
            float attackPosX = playerMovement.lastX;
            float attackPosY = playerMovement.lastY;

            Vector2 rawAttackCoordinates = new Vector2(attackPosX, attackPosY);
            Vector3 rawAttackPos = rawAttackCoordinates.normalized * dashRange;
            dashDirection = transform.position + rawAttackPos;
        }
    }
}
