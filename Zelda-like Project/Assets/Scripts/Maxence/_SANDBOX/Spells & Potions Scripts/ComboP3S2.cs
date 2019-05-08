using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP3S2 : MonoBehaviour
{
    // 

    private Behavior behavior;

    //private Invisible invisibleScript;

    private bool isTrigger = false;

    private float timer = 0.25f;

    private void Update()
    {
        if (!isTrigger)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject enemy = other.transform.parent.parent.gameObject;

            isTrigger = true;

            behavior = enemy.GetComponent<EnemyBehaviorsManager>().enemyMovement;

            //invisibleScript = enemy.GetComponent<Invisible>();

            StartCoroutine(ComboEffect(8f));
        }
    }

    IEnumerator ComboEffect(float timer)
    {
        behavior.enemyGlobalSpeed /= 2;

        //invisibleScript.enabled = false;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(timer);

        behavior.enemyGlobalSpeed *= 2;

        //invisibleScript.enabled = true;

        Destroy(gameObject);
    }
}
