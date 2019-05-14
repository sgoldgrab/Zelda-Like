using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tipheret : Sephiroth
{
    private bool effect = false;

    private GameObject player;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(isActive && !effect)
        {
            playerMovement.playerSpeed *= 1.3f;
            effect = true;
        }
    }
}
