using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyOfPetrificaion : PickUp
{
    //During 5 seconds, makes the player immune to damage, but prevents him from attacking casting abilities or using consumables

    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    private Inventory inventory;
    private PlayerState playerState;
    private PlayerAbilities playerAbilities; //rajouté au vue de la description donnée, avec le bool canUseAbility

    public override void Consume()
    {
        base.Consume();

        playerMovement = player.GetComponent<PlayerMovement>();
        playerAttack = player.GetComponent<PlayerAttack>();
        inventory = player.GetComponent<Inventory>();
        playerState = player.GetComponent<PlayerState>();
        playerAbilities = player.GetComponent<PlayerAbilities>();

        StartCoroutine(LilyEffect(5f));
    }

    IEnumerator LilyEffect(float time)
    {
        playerState.isImmune = true;
        playerMovement.canMove = false;
        playerAttack.canAttack = false;
        playerAbilities.canUseAbility = false;
        inventory.canUseConsumable = false;

        yield return new WaitForSeconds(time);

        playerState.isImmune = false;
        playerMovement.canMove = true;
        playerAttack.canAttack = true;
        playerAbilities.canUseAbility = true;
        inventory.canUseConsumable = true;

        Destroy(gameObject);
    }

}
