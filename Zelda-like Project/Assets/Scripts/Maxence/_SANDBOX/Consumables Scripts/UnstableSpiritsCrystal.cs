using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableSpiritsCrystal : PickUp
{
    //grants the player +1 dmg on his next attack every time he switches stance during 7,5 seconds
    //needs to be tested with enemies to hit 1 and see iof the damage bonus fades away as intended

    private PlayerAttack playerAttack;
    private PlayerStance playerStance;

    public override void Consume()
    {
        base.Consume();
        playerAttack = player.GetComponent<PlayerAttack>();
        playerStance = player.GetComponent<PlayerStance>();
        StartCoroutine(CrystalEffect(7.5f));
    }

    private void AttackBuff()
    {
        playerAttack.attackDamage += 1;
        playerStance.beenBuffed = true;
    }

    private void AttackDebuff()
    {
        playerAttack.attackDamage -= 1;
        playerStance.beenBuffed = false;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PlayerStance.whenPlayerSwitches -= AttackBuff;
        EnemyState.whenEnemyHit -= AttackDebuff;
    }

    IEnumerator CrystalEffect(float time)
    {
        PlayerStance.whenPlayerSwitches += AttackBuff;
        EnemyState.whenEnemyHit += AttackDebuff;
        yield return new WaitForSeconds(time);
        if (playerStance.beenBuffed) { playerAttack.attackDamage -= 1; }
        playerStance.beenBuffed = false;
        Destroy(gameObject);
    }
}
