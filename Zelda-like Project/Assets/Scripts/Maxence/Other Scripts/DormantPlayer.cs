using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DormantPlayer : MonoBehaviour
{
    public GameObject player;
    private PlayerControllerEzEz playerController;

    public int enemiesTouchedCount;

    public GameObject[] playerHealth; // --> définir une liste dans l'inspector...

    /*public GameObject playerHealthOne; // --> ...à ranger dans l'ordre décroissant ; ex: playerHealth[0] = playerHealthFive, etc.
    public GameObject playerHealthTwo;
    public GameObject playerHealthThree;
    public GameObject playerHealthFour;
    public GameObject playerHealthFive;*/

    public bool immuneToDamage = false;

    public int damageAbsorbed = 0;

    private float damageTaken; // connection à un autre script à faire

    private void Start()
    {
        player = GameObject.Find("Player");

        playerController = player.GetComponent<PlayerControllerEzEz>();
    }

    public void Pot1Effect()
    {
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

        //rend 1HP toutes les 3 sec, 3 fois

        /*yield return new WaitForSeconds(3f);

        if (damageTaken == 1)
        {
            playerHealthFive.SetActive(true);
            damageTaken -= 1;
        }

        if (damageTaken == 2)
        {
            playerHealthFour.SetActive(true);
            damageTaken -= 1;
        }

        if (damageTaken == 3)
        {
            playerHealthThree.SetActive(true);
            damageTaken -= 1;
        }

        if (damageTaken == 4)
        {
            playerHealthTwo.SetActive(true);
            damageTaken -= 1;
        }

        yield return new WaitForSeconds(3f);

        if (damageTaken == 1)
        {
            playerHealthFive.SetActive(true);
            damageTaken -= 1;
        }

        if (damageTaken == 2)
        {
            playerHealthFour.SetActive(true);
            damageTaken -= 1;
        }

        if (damageTaken == 3)
        {
            playerHealthThree.SetActive(true);
            damageTaken -= 1;
        }

        if (damageTaken == 4)
        {
            playerHealthTwo.SetActive(true);
            damageTaken -= 1;
        }

        yield return new WaitForSeconds(3f);

        if (damageTaken == 1)
        {
            playerHealthFive.SetActive(true);
            damageTaken -= 1;
        }

        if (damageTaken == 2)
        {
            playerHealthFour.SetActive(true);
            damageTaken -= 1;
        }

        if (damageTaken == 3)
        {
            playerHealthThree.SetActive(true);
            damageTaken -= 1;
        }

        if (damageTaken == 4)
        {
            playerHealthTwo.SetActive(true);
            damageTaken -= 1;
        }*/
    }

    public void Pot2Effect()
    {
        //attackDamage est une public int définie sur le script du playerController qui influe sur le script du prefab de l'attaque du joueur

        StartCoroutine(PotTwo());
    }

    IEnumerator PotTwo()
    {
        //augmente les dégâts infligés de 1, sur le script du prefab de l'attaque le nb d'HP qu'on enlève aux ennemis sera égale à la valeur de "attackDamage"

        player.attackDamage += 1;

        yield return new WaitForSeconds(7f);

        player.attackDamage -= 1;
    }

    public void Pot3Effect()
    {
        //valeur du rayon de la lumière permanente autour du joueur * 2
        //doubler la vision
    }

    public void Spell1AndPot1Effect()
    {
        //rend 1HP pour chaque ennemi touché, le compte est gardé avec la variable "compteurEnnemisTouches"

        for(int w = enemiesTouchedCount; w > 0; w--)
        {
            for (int y = 0; y < 4; y++)
            {
                if (damageTaken == y)
                {

                    playerHealth[y].SetActive(true);
                    damageTaken -= 1;

                }
            }

            /*if (damageTaken == 1)
            {
                playerHealthFive.SetActive(true);
                damageTaken -= 1;
            }

            if (damageTaken == 2)
            {
                playerHealthFour.SetActive(true);
                damageTaken -= 1;
            }

            if (damageTaken == 3)
            {
                playerHealthThree.SetActive(true);
                damageTaken -= 1;
            }   

            if (damageTaken == 4)
            {
                playerHealthTwo.SetActive(true);
                damageTaken -= 1;
            }*/
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
