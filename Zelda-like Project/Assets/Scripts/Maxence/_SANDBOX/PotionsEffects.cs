using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsEffects : MonoBehaviour
{
    protected PlayerState playerState;
    protected PlayerAttack playerAttack;
    protected PlayerSight playerSight;

    [SerializeField] private float bonusTime;
    private float bonus;
    public float bonusCooldown { get => bonusTime; set => bonusTime = value; }

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
        playerSight = GetComponent<PlayerSight>();
        playerAttack = GetComponent<PlayerAttack>();

        bonus = bonusTime;
    }

    public void Effect(int value, float time, int index)
    {
        StartCoroutine(PotionEffect(value, time, index));
    }

    IEnumerator PotionEffect(int value, float time, int index)
    {
        if (index == 0) // Potion 1
        {
            yield return new WaitForSeconds(time - (bonus / 3));

            playerState.TakeHeal(value);

            yield return new WaitForSeconds(time - (bonus / 3));

            playerState.TakeHeal(value);

            yield return new WaitForSeconds(time - (bonus / 3));

            playerState.TakeHeal(value);
        }

        if (index == 1) // Potion 2
        {
            playerAttack.attackDamage += value;

            yield return new WaitForSeconds(time + bonus);

            playerAttack.attackDamage -= value;
        }

        if (index == 2) // Potion 3
        {
            playerSight.aware = true;

            yield return new WaitForSeconds(time + bonus);

            playerSight.aware = false;
        }
    }
}