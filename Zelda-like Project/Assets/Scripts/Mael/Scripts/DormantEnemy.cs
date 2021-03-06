﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DormantEnemy : MonoBehaviour
{

    private Rigidbody2D rb2D;

    private GameObject player;
    //private PlayerControllerEzEz playerController; // changé

    private float speed;

    public GameObject[] enemyHealth; // --> définir une liste dans l'inspector...

    /*public GameObject enemyHealthOne; // --> ...à ranger dans l'ordre décroissant ; ex: enemyHealth[0] = playerHealthThree, etc.
    public GameObject enemyHealthTwo;
    public GameObject enemyHealthThree;*/

    //AJOUTS\\

    private float directionX;
    private float directionY;

    private float damageTaken; // connection à un autre script à faire

    public DormantPlayer dormantPlayer;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        player = GameObject.Find("Player");

       // playerController = player.GetComponent<PlayerControllerEzEz>(); // changé

        
    }

    public void Spell1Effect()
    {
        //appelée lorsque l'ennemi est touché par le spell 1
        print("spell1");
        StartCoroutine(SpellOne());
    }

    IEnumerator SpellOne()
    {
        //ça enlève 1 HP toutes les 2 sec 2 fois

        for (int u = 0; u < 2; u++)
        {
            for (int i = 0; i < 4; i++)
            {
                if (damageTaken == i)
                {
                    enemyHealth[i].SetActive(true);
                    damageTaken -= 1;
                }
            }

            yield return new WaitForSeconds(2f);
        }

        /*yield return new WaitForSeconds(2f);

        if(damageTaken == 0)
        {
            enemyHealthThree.SetActive(false);
            damageTaken += 1;
        }

        if (damageTaken == 1)
        {
            enemyHealthThree.SetActive(false);
            damageTaken += 1;
        }

        if (damageTaken == 2)
        {
            enemyHealthOne.SetActive(false);
            Destroy(gameObject);
        }

        yield return new WaitForSeconds(2f);

        if (damageTaken == 0)
        {
            enemyHealthThree.SetActive(false);
            damageTaken += 1;
        }

        if (damageTaken == 1)
        {
            enemyHealthThree.SetActive(false);
            damageTaken += 1;
        }

        if (damageTaken == 2)
        {
            enemyHealthOne.SetActive(false);
            Destroy(gameObject);
        }*/
    }

    //appelée lorsque l'ennemi est touché par le spell 2
    //ça pull back les ennemis dans la direction du spell, tant qu'ils sont à la bonne portée, ici j'ai mis 2 au pif mais on calibrera

    public void Spell2Effect()
    {

        print("spell2");
        bool spell2Touched = true;

        rb2D.AddForce(new Vector2(directionX, directionY)); //on récupère ici la direction que le spell a pris

        if (spell2Touched && Vector2.Distance(transform.position, player.transform.position) > 2)
        {
            rb2D.AddForce(new Vector2(-directionX, -directionY)); //l'opposé de la force qu'on a mise avant
            spell2Touched = false; //annule le current behavior de l'ennemi
        }
    }

    public void Spell1AndPot1()
    {
        //appelée lorsque l'ennemi est touché par le spell 1 combo dans la pot 1
        //enlève 1HP et ajoute 1 au compteur d'ennemis touchés, utile pour le script sur le joueur 

        if (damageTaken == 0)
        {
            enemyHealth[0].SetActive(false);
            dormantPlayer.enemiesTouchedCount += 1;
            damageTaken += 1;
        }

        if (damageTaken == 1)
        {
            enemyHealth[1].SetActive(false);
            dormantPlayer.enemiesTouchedCount += 1;
            damageTaken += 1;
        }

        if (damageTaken == 2)
        {
            enemyHealth[2].SetActive(false);
            Destroy(gameObject);
            dormantPlayer.enemiesTouchedCount += 1;
        }
    }

    public void Spell1AndPot2()
    {
        //appelée lorsque l'ennemi est touché par le spell 1 combo dans la pot 2
        //enlève 2HP

        if (damageTaken == 0)
        {
            enemyHealth[0].SetActive(false);
            enemyHealth[1].SetActive(false);
            damageTaken += 1;
        }

        if (damageTaken == 1)
        {
            enemyHealth[1].SetActive(false);
            enemyHealth[2].SetActive(false);
            Destroy(gameObject);
            damageTaken += 1;
        }

        if (damageTaken == 2)
        {
            enemyHealth[2].SetActive(false);
            Destroy(gameObject);
        }
    }

    public void Spell2AndPot2()
    {
        //appelée lorsque l'ennemi est touché par le spell 2 combo dans la pot 2
        //je pense que cet effet là c'est pas possible de le foutre sur l'ennemi on est olbigé de le laisser sur le prefab
    }

    public void Spell2AndPot3()
    {
        //appelée lorsque l'ennemi est touché par le spell 2 combo dans la pot 3

        StartCoroutine(ComboSpell2Pot3());
    }

    IEnumerator ComboSpell2Pot3()
    {
        //divise la vitesse par 2 et le rend glow, donc visible tout le temps, pendant 6 sec

        speed = speed / 2;
        //Set la bool du script "glow" à true
        yield return new WaitForSeconds(6);
        speed = speed * 2;
        //Set la bool du script "glow" à false
    }

    public void Spell3AndPot1()
    {
        //appelée lorsque l'ennemi est touché par le spell 3 combo dans la pot 1
        //???
    }

}
