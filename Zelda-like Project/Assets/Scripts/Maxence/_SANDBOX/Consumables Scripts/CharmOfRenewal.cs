using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharmOfRenewal : PickUp
{
    //Heals the player every 2 second during 6 seconds (3 times), but locks him in his current stance during the effect

    private PlayerState playerState;
    private PlayerStance playerStance;

    public override void Consume()
    {
        base.Consume();
        playerState = player.GetComponent<PlayerState>();
        playerStance = player.GetComponent<PlayerStance>();
        StartCoroutine(CharmEffect(2f, 1));
    }

    IEnumerator CharmEffect(float time, int healingAmount)
    {
        playerStance.canSwitch = false;
        yield return new WaitForSeconds(time);
        playerState.TakeHeal(healingAmount);
        yield return new WaitForSeconds(time);
        playerState.TakeHeal(healingAmount);
        yield return new WaitForSeconds(time);
        playerState.TakeHeal(healingAmount);
        playerStance.canSwitch = true;
        Destroy(gameObject);
    }

}
