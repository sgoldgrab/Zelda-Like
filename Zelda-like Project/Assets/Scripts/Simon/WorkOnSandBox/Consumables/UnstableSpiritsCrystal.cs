﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableSpiritsCrystal : PickUp
{

    #region Variables
    private TestSimonPlayerAttack attackScript;
    private TestSimonPlayerStance stanceScript;
    #endregion

    public override void Consume()
    {
        base.Consume();
        attackScript = player.GetComponent<TestSimonPlayerAttack>();
        stanceScript = player.GetComponent<TestSimonPlayerStance>();
        StartCoroutine(CrystalEffect(7.5f));
    }

    private void AttackBuff()
    {
        attackScript.attackDamage += 1;
        stanceScript.beenBuffed = true;
    }

    private void AttackDebuff()
    {
        attackScript.attackDamage -= 1;
        stanceScript.beenBuffed = false;
    }

    private void OnDisable()
    {
        TestSimonPlayerStance.whenPlayerSwitches -= AttackBuff;
        TestSimonEnemyState.whenEnemyHit -= AttackDebuff;
    }

    IEnumerator CrystalEffect (float time)
    {
        TestSimonPlayerStance.whenPlayerSwitches += AttackBuff;
        TestSimonEnemyState.whenEnemyHit += AttackDebuff;
        int temper = attackScript.attackDamage;
        yield return new WaitForSeconds(time);
        attackScript.attackDamage = temper;
        stanceScript.beenBuffed = false;
        Destroy(this);
    }

}