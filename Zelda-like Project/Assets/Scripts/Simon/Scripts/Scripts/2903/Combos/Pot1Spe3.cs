using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot1Spe3 : MonoBehaviour
{
    //augmente les vitesses d'attaque et de déplacement du player ; works just fine

    #region Variables
    private PlayerMovement movementsScript;
    private PlayerAttack attackScript;

    private bool enemyHit = false;

    private float timer = 0.25f;
    #endregion

    private void OnTriggerEnter2D(Collider2D player)
    {
        
        if(player.CompareTag("Player"))
        {

            enemyHit = true;

            movementsScript = player.GetComponent<PlayerMovement>();
            attackScript = player.GetComponent<PlayerAttack>();

            StartCoroutine(ComboEffect(8f));

        }

    }

    IEnumerator ComboEffect(float time)
    {

        //attackScript.attackSpeed *= 2; AJOUTER LA FLOAT ATTACK SPEED DANS PLAYER ATTACK

        movementsScript.playerSpeed *= 2;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        sprite.enabled = false;

        CircleCollider2D collider = GetComponent<CircleCollider2D>();

        collider.enabled = false;

        yield return new WaitForSeconds(time);

        //attackScript.attackSpeed /= 2; 

        movementsScript.playerSpeed /= 2;

        Destroy(gameObject);

    }

    private void Update()
    {

        if (!enemyHit)
        {

            timer -= Time.deltaTime;

            if (timer <= 0)
            {

                Destroy(gameObject);

            }

        }

    }

}
