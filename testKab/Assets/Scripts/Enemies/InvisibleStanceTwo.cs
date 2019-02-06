using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleStanceTwo : MonoBehaviour
{

    private SpriteRenderer sprite;

    private GameObject player;
    private Stances playerStance;

    private void Start()
    {

        sprite = GetComponent<SpriteRenderer>();

        player = GameObject.Find("Player");

        playerStance = player.GetComponent<Stances>();

    }

    private void Update()
    {

        if (playerStance.stanceOne)
        {

            sprite.enabled = true;

        }

        else if (!playerStance.stanceOne)
        {

            sprite.enabled = false;

        }

    }
}
