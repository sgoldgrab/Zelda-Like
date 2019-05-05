using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrisSoakedInMoonlight : PickUp
{
    //grants the player +10 CDR, and +10 CDR each time he kills an enemy for 10s
    //works well, have to test when killing an enemy, and have to create a cooldownReduction float that decreases the cooldow of each ability

    #region Variables
    private TestSimonCooldownReduction abilitiesScript;
    #endregion

    public override void Consume()
    {
        base.Consume();
        abilitiesScript = player.GetComponent<TestSimonCooldownReduction>();
        StartCoroutine(IrisEffect(10f));
    }

    private void OnDisable()
    {
        TestSimonEnemyState.whenEnemyDies -= CDRbuff;
    }

    private void CDRbuff()
    {
        abilitiesScript.cooldownReduction += 10;
    }

    IEnumerator IrisEffect(float time)
    {
        TestSimonEnemyState.whenEnemyDies += CDRbuff;
        int temper = abilitiesScript.cooldownReduction;
        abilitiesScript.cooldownReduction +=10;
        yield return new WaitForSeconds(time);
        abilitiesScript.cooldownReduction = temper;
        Destroy(gameObject);
    }

}
