using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hokhmah : AllSephiroths
{
    private PlayerAbilities playerAbilities;

    private void Awake()
    {
        playerAbilities = GetComponent<PlayerAbilities>();
    }

    private void Update()
    {
        if(isActive)
        {
            /* playerAbilities.cooldownReduction += 20; */
            isActive = false;
        }
    }
}
