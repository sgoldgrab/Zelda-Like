﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1S1 : MonoBehaviour
{

    private DormantEnemy dormantEnemyScript;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Templar")) //Faudra mettre le tag "Enemy" sur tous les ennemis
        {

            dormantEnemyScript = other.gameObject.GetComponent<DormantEnemy>();

            dormantEnemyScript.Spell1AndPot1();

            Destroy(this.gameObject);

        }

    }

}
