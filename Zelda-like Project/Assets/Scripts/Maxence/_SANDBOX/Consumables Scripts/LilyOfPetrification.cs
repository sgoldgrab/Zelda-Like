using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyOfPetrification : PickUp
{
    //During 5 seconds, makes the player immune to damage, but prevents him from attacking casting abilities or using consumables

    private PlayerAttack playerAttack;
    private PlayerState playerState;
    private PlayerAbilities playerAbilities; //rajouté au vue de la description donnée, avec le bool canUseAbility

    public override void Consume()
    {
        base.Consume();

        playerAttack = player.GetComponent<PlayerAttack>();
        playerState = player.GetComponent<PlayerState>();
        playerAbilities = player.GetComponent<PlayerAbilities>();

        StartCoroutine(LilyEffect(5f));
    }

    IEnumerator LilyEffect(float time)
    {
        playerState.immunities += 1;
        playerAttack.canAttack = false;
        playerAbilities.canUseAbility = false;
        inventory.canUseConsumable = false;

        yield return new WaitForSeconds(time);

        playerState.immunities -= 1;
        playerAttack.canAttack = true;
        playerAbilities.canUseAbility = true;
        inventory.canUseConsumable = true;

        Destroy(gameObject);
    }
}
