using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot3Spe3 : MonoBehaviour
{
    //crée une smoke qui rend le joueur insensible ; je sais pas comment incrémenter cette petite salope de damageAbsorbed

    /*
    [TagSelector]
    public string TagFilter = "";

    [TagSelector]
    public string[] TagFilterArray = new string[] { };
    */

    #region Variables
    private Health healthScript;

    private float timer = 6f;
    #endregion

    private void OnTriggerStay2D(Collider2D player)
    {
        
        if(player.CompareTag("Player"))
        {

            healthScript = player.GetComponent<PlayerStatistics>().healthStats;

            if (healthScript.damageAbsorbed < 4)
            {

                healthScript.isImmune = true;

            }

            else if(healthScript.damageAbsorbed >= 4) //on voit bien la variable augmenter dans l'inspector mais ce else if ne se fait jamais, ce fils de pute
            {

                healthScript.isImmune = false;

                healthScript.damageAbsorbed = 0;

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

            healthScript.damageAbsorbed = 0; //ça ça se fait bien, communication ok entre les scripts

            Destroy(gameObject);

        }

    }

}
