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

    private PlayerMovement movements;

    [SerializeField] private GameObject spellOnePrefab;

    [SerializeField] private GameObject spellTwoPrefab;

    [SerializeField] private GameObject spellThreePrefab;

    private Vector2 trsfrmPute;

    #endregion

    private void Awake()
    {

        stanceScript = GetComponent<PlayerStance>();

        healthScript = GetComponent<PlayerStatistics>().healthStats;

        statsScript = GetComponent<PlayerStatistics>().otherStats;

        movements = GetComponent<PlayerMovement>();

    }

    private void Update()
    {
        trsfrmPute = transform.position;
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

            GameObject projectile1 = Instantiate(spellOnePrefab, transform.position, Quaternion.identity);
            projectile1.GetComponent<AbilitySpellOne>().SetDirection(movements.direction);

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

            GameObject projectile2 = Instantiate(spellTwoPrefab, trsfrmPute + movements.direction, Quaternion.identity);
            projectile2.GetComponent<AbilitySpellTwo>().SetDirection(movements.direction);

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

            Instantiate(spellThreePrefab, trsfrmPute + movements.direction * 3, Quaternion.identity);

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
