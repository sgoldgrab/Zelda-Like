using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDormantEffects : MonoBehaviour
{
    public GameObject player;

    public int enemiesTouchedCount;

    public GameObject[] playerHealth;

    public bool immuneToDamage = false;

    public int damageAbsorbed = 0;

    private float damageTaken;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public void Pot1Effect()
    {
        print("pot1");
        StartCoroutine(PotOne());
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
        //rend 1HP pour chaque ennemi touché, le compte est gardé avec la variable "compteurEnnemisTouches"

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

    private void Spell3AndPot3Effect(Collider2D otherOther)
    {
        //quand le joueur entre dans la smoke il gagne l'effet d'absorbtion de damage tant qu'il a absorbé moins de 3 attaques

        if (otherOther.CompareTag("Smoke"))
        {
            if (damageAbsorbed < 4)
            {
                immuneToDamage = true;

                //tant que cette bool est true, chaque attaque subit du player, au lieu d'enlever 1 segement de vie, augmente l'int damageAbsorbed de 1
                //donc dans le update du playercontroller on met un if immuneToDamage true, alors ....? et là je sais pas trop
            }

            if (otherOther.CompareTag("Smoke"))
            {
                immuneToDamage = false;
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
