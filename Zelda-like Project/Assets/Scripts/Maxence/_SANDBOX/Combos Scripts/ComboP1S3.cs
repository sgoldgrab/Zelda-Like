using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP1S3 : MonoBehaviour
{
    //augmente les vitesses d'attaque et de déplacement du player ; works just fine --> CONFIRMED

    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;

    private bool isTrigger = false;

    private float timer = 0.25f;

    private void Update()
    {
        if (!isTrigger)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = other.transform.parent.parent.gameObject;

        if (player.CompareTag("Player"))
        {
            isTrigger = true;

            playerMovement = player.GetComponent<PlayerMovement>();
            playerAttack = player.GetComponent<PlayerAttack>();

            StartCoroutine(ComboEffect(8f));
        }
    }

    IEnumerator ComboEffect(float time)
    {
        playerAttack.attackCoolDownSpeed /= 2; // --> (voir attack script) : la vitesse d'att y est définie par le cooldowns entre chaque inputs, donc on la réduit pour aller plus vite
        playerMovement.playerSpeed *= 2;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(time);

        playerAttack.attackCoolDownSpeed *= 2;
        playerMovement.playerSpeed /= 2;

        Destroy(gameObject);
    }
}
