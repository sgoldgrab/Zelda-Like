using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    public Animator playerAnimator { get; private set; }

    public AnimationState playerAnimState { get; set; }

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private PlayerStance playerStance;
    [SerializeField] private PlayerState playerState;

    void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        //playerAnimState = playerAnimator.GetComponentInChildren<AnimationState>();
    }

    void Update()
    {
        MoveAnim();

        IdleAnim();

        Stance();
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

    public void Stance()
    {
        if (playerStance.whatStance == PlayerStance.Stance.stance1) playerAnimator.SetInteger("stance", 1);
        else if (playerStance.whatStance == PlayerStance.Stance.stance2) playerAnimator.SetInteger("stance", 2);
    }

    public void AbilityToUseInAnim(int layer)
    {
        for (int L = 0; L < 3; L++) // reset all layers to 0
        {
            playerAnimator.SetLayerWeight(L, 0);
        }

        playerAnimator.SetLayerWeight(layer, 1); // set the right layer to 1
    }

    public void ReleaseAnim()
    {
        playerAnimator.SetTrigger("playerRelease");
    }

    public void DrinkAnim()
    {
        playerAnimator.SetTrigger("playerDrinks");
    }

    public void HoldAnim()
    {
        playerAnimator.SetTrigger("playerHolds");
    }

    /// EVENTS \\\

    public void OnDeath()
    {
        //
    }

    public void Recover()
    {
        playerMovement.canMove = true;
    }

    public void Attack()
    {
        playerAttack.SwordAttack();
    }

    public void AttackClear()
    {
        playerAttack.Clear();
    }
}
