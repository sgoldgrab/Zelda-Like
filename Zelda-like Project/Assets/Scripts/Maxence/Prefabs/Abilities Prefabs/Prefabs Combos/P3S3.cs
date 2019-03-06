using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3S3 : MonoBehaviour
{

    //ce prefab doit avoir le tag smoke

    private PlayerDormantEffects dormantPlayerScript;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player")) 
        {

            dormantPlayerScript = other.gameObject.GetComponent<PlayerDormantEffects>();

            dormantPlayerScript.Spell3AndPot3Effect();

        }

    }

}
