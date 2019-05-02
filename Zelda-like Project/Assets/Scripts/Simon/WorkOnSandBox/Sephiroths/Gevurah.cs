using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gevurah : AllSephiroths
{

    private PlayerState playerState;

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        playerState.maxHealth += 1;
        isActive = false;
    }
}
