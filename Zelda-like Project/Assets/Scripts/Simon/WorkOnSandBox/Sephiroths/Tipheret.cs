using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tipheret : AllSephiroths
{

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        playerMovement.playerSpeed *= 1.3f;
        isActive = false;
    }
}
