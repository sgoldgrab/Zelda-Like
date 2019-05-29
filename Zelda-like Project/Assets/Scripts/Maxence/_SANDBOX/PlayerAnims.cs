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

    private AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        playerAnimator = GetComponentInChildren<Animator>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        //playerAnimState = playerAnimator.GetComponentInChildren<AnimationState>();

        playerAnimator.SetFloat("speedAnim", 1f);

        //TESTING
        playerAnimator.SetLayerWeight(1, 1f);
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

            audioManager.PlaySound("PlayerDeath");
        }
    }

    public void AttackAnim()
    {
        playerAnimator.SetTrigger("playerAttacks");

        audioManager.PlaySound("PlayerAttack");
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
            playerAnimator.SetLayerWeight(L + 1, 0);
        }

        playerAnimator.SetLayerWeight(layer, 1); // set the right layer to 1
    }

    public void ReleaseAnim()
    {
        playerAnimator.SetTrigger("playerRelease");

        if (playerStance.whatStance == PlayerStance.Stance.stance1) audioManager.PlaySound("ThrowPotion");
    }

    public void DrinkAnim()
    {
        playerAnimator.SetTrigger("playerDrinks");

        audioManager.PlaySound("DrinkPotion");
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
