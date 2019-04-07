using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoudreDePerlimpinpin : PickUpScript
{

    public override void ConsumableUse()
    {

        base.ConsumableUse();
        StartCoroutine(ConsumableEffect(10f));

    }

    IEnumerator ConsumableEffect(float time)
    {

        statsScript.cooldownReduction += 6f;

        statsScript.attackSpeed *= 2f;

        yield return new WaitForSeconds(time);

        statsScript.cooldownReduction -= 6f;

        statsScript.attackSpeed /= 2f;

        Destroy(this);

    }

}
