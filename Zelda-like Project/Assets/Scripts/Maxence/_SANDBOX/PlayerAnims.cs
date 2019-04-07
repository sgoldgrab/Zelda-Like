using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerState playerState;

    void OnValidate()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        MoveAnim();

        IdleAnim();
    }

    void MoveAnim()
    {
        playerAnimator.SetFloat("x", playerMovement.horizontal);
        playerAnimator.SetFloat("y", playerMovement.vertical);
    }

    void IdleAnim()
    {
        if (playerMovement.lastX > 0) { playerAnimator.SetFloat("lastX", 1); }
        if (playerMovement.lastX < 0) { playerAnimator.SetFloat("lastX", -1); }
        if (playerMovement.lastY > 0) { playerAnimator.SetFloat("lastY", 1); }
        if (playerMovement.lastY < 0) { playerAnimator.SetFloat("lastY", -1); }
    }

    public void DamageAnim()
    {
        if (playerState.health > 0)
        {
            playerAnimator.SetTrigger("playerIsHit");
        }

        else if (playerState.health <= 0)
        {
            playerAnimator.SetTrigger("playerIsDead");
        }
    }

    public void AttackAnim()
    {
        playerAnimator.SetTrigger("playerAttacks");
    }
}
