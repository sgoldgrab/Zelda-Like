using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavensGraceDust : PickUp
{

    #region Variables
    TestSimonPlayerState healthScript;
    #endregion

    public override void Consume()
    {
        base.Consume();
        healthScript = player.GetComponent<TestSimonPlayerState>();
        StartCoroutine(DustEffect(6f));
    }

    IEnumerator DustEffect (float time)
    {
        while(healthScript.health == 1) { healthScript.isImmune = true; }
        yield return new WaitForSeconds(time);
        Destroy(this);
    }

}
