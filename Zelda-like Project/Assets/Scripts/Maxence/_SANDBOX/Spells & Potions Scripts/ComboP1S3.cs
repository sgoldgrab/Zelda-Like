﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP1S3 : MonoBehaviour
{
    //augmente les vitesses d'attaque et de déplacement du player ; works just fine --> CONFIRMED

    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;

    private Animator playerAnimator;

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
        if (other.CompareTag("Player"))
        {
            GameObject player = other.transform.parent.parent.gameObject;

            isTrigger = true;

            playerMovement = player.GetComponent<PlayerMovement>();
            playerAttack = player.GetComponent<PlayerAttack>();
            playerAnimator = player.GetComponentInChildren<Animator>();

            StartCoroutine(ComboEffect(8f));
        }
    }

    IEnumerator ComboEffect(float time)
    {
        playerAttack.attackCoolDownSpeed /= 1.5f; // --> (voir attack script) : la vitesse d'att y est définie par le cooldowns entre chaque inputs, donc on la réduit pour aller plus vite
        playerMovement.playerSpeed *= 2f;
        playerAnimator.SetFloat("speedAnim", 1.5f);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(time);

        playerAttack.attackCoolDownSpeed *= 1.5f;
        playerMovement.playerSpeed /= 2f;
        playerAnimator.SetFloat("speedAnim", 1f);

        Destroy(gameObject);
    }
}
