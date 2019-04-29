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

    private void OnEnable()
    {
        TestSiimonEnemyManager.whenEnemyDies += CDRbuff;
    }

    private void OnDisable()
    {
        TestSiimonEnemyManager.whenEnemyDies -= CDRbuff;
    }

    private void CDRbuff()
    {
        abilitiesScript.cooldownReduction += 10;
    }

    IEnumerator IrisEffect(float time)
    {
        abilitiesScript.cooldownReduction +=10;
        yield return new WaitForSeconds(time);
        Destroy(this);
    }

}
