using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavensGraceDust : PickUp
{
    //makes the player immune to lethal damage 
    //has to be testes with HP that aren't broken

    PlayerState playerState;

    private bool activated;
    private bool immune;

    void Update()
    {
        if (activated)
        {
            if (playerState.health == 1 && !immune)
            {
                playerState.immunities += 1;
                immune = true;
            }
        }
    }

    public override void Consume()
    {
        base.Consume();
        activated = true;
        playerState = player.GetComponent<PlayerState>();
        StartCoroutine(DustEffect(6f));
    }

    IEnumerator DustEffect(float time)
    {
        yield return new WaitForSeconds(time);
        if (immune) playerState.immunities -= 1;
        Destroy(gameObject);
    }
}
