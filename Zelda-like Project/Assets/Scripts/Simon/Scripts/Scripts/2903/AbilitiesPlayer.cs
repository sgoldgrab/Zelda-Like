using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesPlayer : MonoBehaviour
{
    #region Variables
    private PlayerStatistics player;

    private PlayerStance stanceScript;

    private Health healthScript;

    private PlayerStats statsScript;

    [SerializeField] private GameObject spellOnePrefab;

    [SerializeField] private GameObject spellTwoPrefab;

    #endregion

    private void Awake()
    {

        stanceScript = GetComponent<PlayerStance>();

        healthScript = GetComponent<PlayerStatistics>().healthStats;

        statsScript = GetComponent<PlayerStatistics>().otherStats;

    }

    public void AbilityOne()
    {

        #region Stance 1
        if(stanceScript.whatStance == PlayerStance.Stance.stanceOne)
        {

            StartCoroutine(EffectPotOne(1, 2.5f));

        }
        #endregion

        #region Stance 2
        if (stanceScript.whatStance == PlayerStance.Stance.stanceTwo)
        {

            Instantiate(spellOnePrefab, transform.position, Quaternion.identity); //l'orienter dans la bonne direction

        }
        #endregion

    }

    public void AbilityTwo()
    {

        #region Stance 1
        if (stanceScript.whatStance == PlayerStance.Stance.stanceOne)
        {

            StartCoroutine(EffectPotTwo(1, 7.5f));

        }
        #endregion

        #region Stance 2
        if (stanceScript.whatStance == PlayerStance.Stance.stanceTwo)
        {

            Instantiate(spellTwoPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);

        }
        #endregion

    }

    public void AbilityThree()
    {

        #region Stance 1
        if (stanceScript.whatStance == PlayerStance.Stance.stanceOne)
        {

            StartCoroutine(EffectPotThree(1, 10f));

        }
        #endregion

        #region Stance 2
        if (stanceScript.whatStance == PlayerStance.Stance.stanceTwo)
        {



        }
        #endregion

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

        statsScript.attackDamage += boostValue;

        yield return new WaitForSeconds(time);

        statsScript.attackDamage -= boostValue;

    }

    IEnumerator EffectPotThree(int boostValue, float time)
    {

        statsScript.rangeOfSight += boostValue;

        yield return new WaitForSeconds(time);

        statsScript.rangeOfSight -= boostValue;

    }

}
