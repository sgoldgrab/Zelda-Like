using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoudreDetaRace : PickUpScript
{

    public override void ConsumableUse()
    {

        base.ConsumableUse();

        StartCoroutine(ConsumableEffect(3f));

    }

    IEnumerator ConsumableEffect(float time)
    {

        float temper = statsScript.movementSpeed;

        healthScript.isImmune = true;

        statsScript.movementSpeed = 0;

        yield return new WaitForSeconds(time);

        healthScript.isImmune = false;

        statsScript.movementSpeed = temper;

        Destroy(gameObject);

    }


}
