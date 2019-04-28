using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocketOfAWIngedSoul : PickUp
{
    //During 10 seconds, increase the range of the dash performed when the player uses a basic attack

    private PlayerAttack playerAttack;

    public override void Consume()
    {
        base.Consume();
        playerAttack = player.GetComponent<PlayerAttack>();
        StartCoroutine(LocketEffect(10f));
    }

    IEnumerator LocketEffect (float time)
    {
        playerAttack.attackMoveTime += 0.2f;
        yield return new WaitForSeconds(time);
        playerAttack.attackMoveTime -= 0.2f;
        Destroy(gameObject);
    }
}
