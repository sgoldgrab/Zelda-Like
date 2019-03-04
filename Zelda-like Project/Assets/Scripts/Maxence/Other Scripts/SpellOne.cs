using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellOne : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timer;

    private DormantEnemy dormantEnemyScript;

    private PlayerAbilitiesBis playerAbilitiesScript;
    private Vector2 direction;

    public void SetPositions(Vector2 pos)
    {
        direction = pos;
    }

    private void Start()
    {
        //penser à lancer l'anim si y'en a une (et si y'a besoin?)
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        transform.Translate(direction * speed * Time.deltaTime);

        if (timer <= 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Templar")) //Faudra mettre le tag "Enemy" sur tous les ennemis
        {
            dormantEnemyScript = other.gameObject.GetComponent<DormantEnemy>();

            dormantEnemyScript.Spell1Effect();

            Destroy(gameObject);
        }

        if (other.CompareTag("Obstacle") || other.CompareTag("Potion1") || other.CompareTag("Potion2"))
        {
            Destroy(gameObject);
        }
    }
}
