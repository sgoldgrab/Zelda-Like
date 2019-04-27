using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotionsEffects : MonoBehaviour
{
    protected PlayerState playerState;
    protected PlayerAttack playerAttack;
    protected PlayerSight playerSight;

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
        playerSight = GetComponent<PlayerSight>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    public abstract void Effect(int value, float time);
}

public class Potion1Effect : PotionsEffects
{
    public override void Effect(int value, float time)
    {
        StartCoroutine(EffectPotOne(value, time));
    }

    IEnumerator EffectPotOne(int healingValue, float time)
    {
        yield return new WaitForSeconds(time);

        playerState.TakeHeal(healingValue);

        yield return new WaitForSeconds(time);

        playerState.TakeHeal(healingValue);

        yield return new WaitForSeconds(time);

        playerState.TakeHeal(healingValue);
    }
}

public class Potion2Effect : PotionsEffects
{
    public override void Effect(int value, float time)
    {
        StartCoroutine(EffectPotTwo(value, time));
    }

    IEnumerator EffectPotTwo(int boostValue, float time)
    {
        playerAttack.attackDamage += boostValue;

        yield return new WaitForSeconds(time);

        playerAttack.attackDamage -= boostValue;
    }
}

public class Potion3Effect : PotionsEffects
{
    public override void Effect(int value, float time)
    {
        StartCoroutine(EffectPotThree(value, time));
    }

    IEnumerator EffectPotThree(int boostValue, float time)
    {
        playerSight.sightZoneRadius += boostValue;

        yield return new WaitForSeconds(time);

        playerSight.sightZoneRadius -= boostValue;
    }
}
