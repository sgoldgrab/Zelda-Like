using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocketOfAWIngedSoul : PickUp
{
    //During 10 seconds, increase the range of the dash performed when the player uses a basic attack
    //Works well, juste have to create a dashValue float in the PlayerAttackScript that increases the dash range

    #region Variables
    private TestSimonPlayerAttack attackScript;
    #endregion

    public override void Consume()
    {
        base.Consume();
        attackScript = player.GetComponent<TestSimonPlayerAttack>();
        StartCoroutine(LocketEffect(10f));
    }

    IEnumerator LocketEffect (float time)
    {
        attackScript.dashDistance += 2.5f;
        yield return new WaitForSeconds(time);
        attackScript.dashDistance -= 2.5f;
        Destroy(gameObject);
    }

}
