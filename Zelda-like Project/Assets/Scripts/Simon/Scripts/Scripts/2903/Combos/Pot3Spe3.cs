using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot3Spe3 : MonoBehaviour
{
    //crée une smoke qui rend le joueur insensible ; je sais pas comment incrémenter cette petite salope de damageAbsorbed

    #region Variables
    private Health healthScript;

    [SerializeField] private int damageAbsorbed = 0;

    private float timer = 6f;
    #endregion

    private void OnTriggerStay2D(Collider2D player)
    {
        
        if(player.CompareTag("Player"))
        {

            healthScript = player.GetComponent<PlayerStatistics>().healthStats;

            if(damageAbsorbed < 4)
            {

                healthScript.isImmune = true;

                //damageAbsorbed++

            }

            else if(damageAbsorbed >= 4)
            {

                healthScript.isImmune = false;

                Destroy(gameObject);

            }

        }

    }

    private void OnTriggerExit2D(Collider2D player)
    {
        
        if(player.CompareTag("Player"))
        {

            healthScript.isImmune = false;

        }

    }

    private void Update()
    {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {

            healthScript.isImmune = false;

            Destroy(gameObject);

        }

    }

}
