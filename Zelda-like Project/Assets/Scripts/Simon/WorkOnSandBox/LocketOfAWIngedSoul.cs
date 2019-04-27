using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocketOfAWIngedSoul : PickUp
{
    //During 10 seconds, increase the range of the dash performed when the player uses a basic attack

    #region Variables
    private PlayerAttack attackScript;
    #endregion

    public override void Consume()
    {
        base.Consume();
        attackScript = player.GetComponent<PlayerAttack>();
        StartCoroutine(LocketEffect(10f));
    }

    IEnumerator LocketEffect (float time)
    {
        //attackScript.dashDistance *= 2.5; AJOUTER LA FLOAT DASH DISTANCE SUR LE SCRIPT PLAYER ATTACK
        yield return new WaitForSeconds(time);
        //attackScript.dashDistance /= 2.5;
        Destroy(this);
    }

}
