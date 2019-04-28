using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsEffects : MonoBehaviour
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

    public void Effect(int value, float time, int index)
    {
        StartCoroutine(PotionEffect(value, time, index));
    }

    IEnumerator PotionEffect(int value, float time, int index)
    {
        if (index == 0) // Potion 1
        {
            yield return new WaitForSeconds(time);

            playerState.TakeHeal(value);

            yield return new WaitForSeconds(time);

            playerState.TakeHeal(value);

            yield return new WaitForSeconds(time);

            playerState.TakeHeal(value);
        }

        if (index == 1) // Potion 2
        {
            playerAttack.attackDamage += value;

            yield return new WaitForSeconds(time);

            playerAttack.attackDamage -= value;
        }

        if (index == 2) // Potion 3
        {
            playerSight.sightZoneRadius += value;

            yield return new WaitForSeconds(time);

            playerSight.sightZoneRadius -= value;
        }
    }
}