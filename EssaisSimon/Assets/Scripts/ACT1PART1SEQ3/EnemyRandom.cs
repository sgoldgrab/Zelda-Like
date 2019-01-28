using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : MonoBehaviour
{

    private GameObject zone;
    private Zone zoneScript;

    private void Start()
    {

        zone = GameObject.Find("Zone");

        zoneScript = zone.GetComponent<Zone>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Zone"))
        {

            zoneScript.enemyOnZone = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Zone"))
        {

            zoneScript.enemyOnZone = false;

        }

    }

}
