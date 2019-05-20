using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP3S2 : MonoBehaviour
{
    private Behavior behavior;

    //private Invisible invisibleScript;

    private bool isTrigger = false;

    [SerializeField] private float timer;

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
        Time.timeScale = 0.3f;

        //invisibleScript.enabled = false;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(timer);

        Time.timeScale = 1.0f;

        //invisibleScript.enabled = true;

        Destroy(gameObject);
    }
}
