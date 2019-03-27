using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3S3 : MonoBehaviour
{
    //ce prefab doit avoir le tag smoke

    private PlayerDormantEffects dormantPlayerScript;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerCaracteristics>().playerResistance <= 100)
            {
                other.GetComponent<PlayerControllerEzEz>().immuneToDamage = true;

                //tant que cette bool est true, chaque attaque subit du player, au lieu d'enlever 1 segement de vie, augmente l'int damageAbsorbed de 1
                //donc dans le update du playercontroller on met un if immuneToDamage true, alors ....? et là je sais pas trop
            }

            else
            {
                other.GetComponent<PlayerControllerEzEz>().immuneToDamage = false;

                Destroy(gameObject);
            }
        }
    }
}
