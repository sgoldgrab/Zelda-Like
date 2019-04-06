using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot1Spe3 : MonoBehaviour
{
    //augmente les vitesses d'attaque et de déplacement du player ; works just fine

    #region Variables
    private PlayerStats playerScript;

    private bool enemyHit = false;

    private float timer = 0.25f;
    #endregion

    private void OnTriggerEnter2D(Collider2D player)
    {
        
        if(player.CompareTag("Player"))
        {

            enemyHit = true;

            playerScript = player.GetComponent<PlayerStatistics>().otherStats;

            StartCoroutine(ComboEffect(8f));

        }

    }

    IEnumerator ComboEffect(float time)
    {

        playerScript.attackSpeed *= 2;

        playerScript.movementSpeed *= 2;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        sprite.enabled = false;

        CircleCollider2D collider = GetComponent<CircleCollider2D>();

        collider.enabled = false;

        yield return new WaitForSeconds(time);

        playerScript.attackSpeed /= 2;

        playerScript.movementSpeed /= 2;

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
