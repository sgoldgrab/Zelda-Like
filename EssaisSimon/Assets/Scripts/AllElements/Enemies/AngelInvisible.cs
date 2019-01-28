using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelInvisible : MonoBehaviour
{

    private GameObject player;
    private Stances stance;
    private SpriteRenderer sprite;

    private void Start()
    {
        player = GameObject.Find("Player");
        stance = player.GetComponent<Stances>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (stance.stanceOne)
        {
            sprite.enabled = false;
        }

        else if (!stance.stanceOne)
        {
            sprite.enabled = true;
        }
    }

}
