using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yesod : AllSephiroths
{

    private TestSimonPlayerAttack attackScript;

    private void Update()
    {
        if (isActive)
        {
            /*attackScript.attackSpeed += 0.5f;*/
            isActive = false;
        }
    }

}
