using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nezah : AllSephiroths
{

    private PlayerAbilities playerAbilities;

    private void Awake()
    {
        playerAbilities = GetComponent<PlayerAbilities>();
    }

    private void Update()
    {
        /* playerAbilities.potionDuration *= 1.3f; */
        isActive = false;
    }
}
