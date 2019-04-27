using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsEffects : MonoBehaviour
{

    #region Variables
    public GameObject player;

    private PlayerState healthScript;
    private PlayerAttack attackScript;
    private PlayerSight sightScript;
    #endregion

    private void Awake()
    {

        healthScript = player.GetComponent<PlayerState>();

        sightScript = player.GetComponent<PlayerSight>();

        attackScript = player.GetComponent<PlayerAttack>();

    }

    IEnumerator EffectPotOne(int healingValue, float time)
    {

        yield return new WaitForSeconds(time);

        healthScript.TakeHeal(healingValue);

        yield return new WaitForSeconds(time);

        healthScript.TakeHeal(healingValue);

        yield return new WaitForSeconds(time);

        healthScript.TakeHeal(healingValue);

    }

    IEnumerator EffectPotTwo(int boostValue, float time)
    {

        //attackScript.swordDamage += boostValue; PASSER SWORD DAMAGE EN PUBLIC SUR LE SCRIPT PLAYER ATTACK

        yield return new WaitForSeconds(time);

        //attackScript.swordDamage -= boostValue;

    }

    IEnumerator EffectPotThree(int boostValue, float time)
    {

        //sightScript.sightZoneRadius += boostValue; PASSER SIGHT ZONE RADIUS EN PUBLIC SUR LE SCRIPT PLAYER SIGHT

        yield return new WaitForSeconds(time);

        //sightScript.sightZoneRadius -= boostValue;

    }

}
