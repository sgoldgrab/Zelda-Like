using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1S3 : MonoBehaviour
{

    private EnemyDormantEffects dormantEnemyScript;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Templar")) //Faudra mettre le tag "Enemy" sur tous les ennemis
        {

            dormantEnemyScript = other.gameObject.GetComponent<EnemyDormantEffects>();

            dormantEnemyScript.Spell3AndPot1();

            Destroy(this.gameObject);

        }

    }

}