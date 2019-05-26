using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrisSoakedInMoonlight : PickUp
{
    //grants the player +10 CDR, and +10 CDR each time he kills an enemy for 10s
    //works well, have to test when killing an enemy, and have to create a cooldownReduction float that decreases the cooldow of each ability

    #region Variables
    private PlayerAbilities playerAbilities;
    #endregion

    public override void Consume()
    {
        base.Consume();
        playerAbilities = player.GetComponent<PlayerAbilities>();
        StartCoroutine(IrisEffect(10f));
    }

    public void OnDisable()
    {
        EnemyState.whenEnemyDies -= CDRbuff;
    }

    private void CDRbuff()
    {
        playerAbilities.reduction += 0.1f;
    }

    IEnumerator IrisEffect(float time)
    {
        EnemyState.whenEnemyDies += CDRbuff;
        float temper = playerAbilities.reduction;
        playerAbilities.reduction += 0.1f;
        yield return new WaitForSeconds(time);
        playerAbilities.reduction = temper;
        Destroy(gameObject);
    }
}
