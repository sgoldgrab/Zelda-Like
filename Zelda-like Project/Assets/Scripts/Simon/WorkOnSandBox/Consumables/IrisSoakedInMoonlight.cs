using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrisSoakedInMoonlight : PickUp
{

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
        Destroy(this);
    }

}
