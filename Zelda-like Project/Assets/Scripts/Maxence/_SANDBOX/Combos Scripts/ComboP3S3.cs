using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP3S3 : MonoBehaviour
{
    //crée une smoke qui rend le joueur insensible ; je sais pas comment incrémenter cette petite salope de damageCount

    /*
    [TagSelector]
    public string TagFilter = "";

    [TagSelector]
    public string[] TagFilterArray = new string[] { };
    */

    private PlayerState playerState;

    private float timer = 6f;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            playerState.isImmune = false;
            playerState.damageCount = 0; //ça ça se fait bien, communication ok entre les scripts

            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.transform.parent.parent.gameObject;

            playerState = player.GetComponent<PlayerState>();

            if (playerState.damageCount < 4)
            {
                playerState.isImmune = true;
            }

            else if (playerState.damageCount >= 4) //on voit bien la variable augmenter dans l'inspector mais ce else if ne se fait jamais, ce fils de pute
            {
                playerState.isImmune = false;
                playerState.damageCount = 0;

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.transform.parent.parent.gameObject;

            playerState.isImmune = false;
        }
    }
}
