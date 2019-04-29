﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharmOfRenewal : PickUp
{
    //Heals the player every 2 second during 6 seconds, but locks him in his current stance during the effect

    #region Variables
    private PlayerState healthScript;
    private PlayerStance stanceScript;
    #endregion

    public override void Consume()
    {
        base.Consume();
        healthScript = player.GetComponent<PlayerState>();
        stanceScript = player.GetComponent<PlayerStance>();
        StartCoroutine(CharmEffect(2f, 1));
    }

    IEnumerator CharmEffect(float time, int healingAmount)
    {
        //stanceScript.canSwitch = false; AJOUTER LA BOOL CAN SWITCH SUR LE SCXRIPT PLAYER STANCE
        yield return new WaitForSeconds(time);
        healthScript.TakeHeal(healingAmount);
        yield return new WaitForSeconds(time);
        healthScript.TakeHeal(healingAmount);
        yield return new WaitForSeconds(time);
        healthScript.TakeHeal(healingAmount);
        //stanceScript.canSwitch = true;
        Destroy(this);
    }

}