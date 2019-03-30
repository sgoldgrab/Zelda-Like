using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySpellOne : MonoBehaviour
{
    #region Variables
    private Health healthScript;

    private SpriteRenderer thisSprite;

    private bool hasHit = false;

    [SerializeField] private float timer;

    [SerializeField] private float speed;

    [SerializeField] private Vector2 direction;
    #endregion

    private void Awake()
    {

        thisSprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0 && !hasHit)
        {

            Destroy(this.gameObject);

        }

        transform.Translate(Vector2.up * speed * Time.deltaTime); //remplacer Vector2.up par la bonne direction

    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        
        if(enemy.CompareTag("Enemy"))
        {

            healthScript = enemy.GetComponent<TemplarStatistics>().healthStats;

            StartCoroutine(EffectSpellOne(1, 2f));

            thisSprite.enabled = false;

        }

    }

    IEnumerator EffectSpellOne(int damageValue, float time)
    {

        hasHit = true;

        yield return new WaitForSeconds(time);

        healthScript.TakeDamage(damageValue);

        yield return new WaitForSeconds(time);

        healthScript.TakeDamage(damageValue);

        Destroy(this.gameObject);

    }

}
