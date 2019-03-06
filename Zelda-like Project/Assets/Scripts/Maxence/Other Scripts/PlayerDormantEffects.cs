using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDormantEffects : MonoBehaviour
{
    [HideInInspector] public int enemiesTouchedCount;

    public GameObject[] playerHealth;

    [HideInInspector] public bool immuneToDamage = false;

    [HideInInspector] public int damageAbsorbed = 0;

    private PlayerControllerEzEz playerControllerScript;

    private float damageTaken;

    private void Start()
    {

        playerControllerScript = GetComponent<PlayerControllerEzEz>();

    }

    public void Pot1Effect()
    {
        print("pot1");
        StartCoroutine(PotOne());
    }

    internal void Spell3AndPot3Effect()
    {
        throw new NotImplementedException();
    }

    IEnumerator PotOne()
    {
        for (int u = 0; u < 3; u++)
        {
            for (int i = 0; i < 4; i++)
            {
                if (damageTaken == i)
                {
                    playerHealth[i].SetActive(true);
                    damageTaken -= 1;
                }
            }

            yield return new WaitForSeconds(3f);
        }        
    }

    public void Pot2Effect()
    {
        //attackDamage est une public int définie sur le script du playerController qui influe sur le script du prefab de l'attaque du joueur
        print("pot2");
        StartCoroutine(PotTwo());
    }

    IEnumerator PotTwo()
    {
        //augmente les dégâts infligés de 1, sur le script du prefab de l'attaque le nb d'HP qu'on enlève aux ennemis sera égale à la valeur de "attackDamage"

        //playerAttackScript.damage *= 2; // attackDamage = damage / test multiplicateur

        yield return new WaitForSeconds(7f);

        //playerAttackScript.damage /= 2; // attackDamage = damage / test division
    }

    public void Pot3Effect()
    {
        print("pot3");
        //valeur du rayon de la lumière permanente autour du joueur * 2
        //doubler la vision
    }

    public void Spell1AndPot1Effect()
    {

        for (int w = enemiesTouchedCount; w > 0; w--)
        {

            for (int y = 0; y < 4; y++)
            {

                if (damageTaken == y)
                {

                    playerHealth[y].SetActive(true);
                    damageTaken -= 1;

                }

            } 
            
        }

    }

    public void Spell3AndPot3Effect(Collider2D otherOther)
    {

        if (otherOther.CompareTag("Smoke"))
        {

            if (playerControllerScript.damageAbsorbed < 4)
            {

                playerControllerScript.immuneToDamage = true;

            }

            if (otherOther.CompareTag("Smoke"))
            {

                playerControllerScript.immuneToDamage = false;

            }

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Spell3AndPot3Effect(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Spell3AndPot3Effect(other);
    }
}
