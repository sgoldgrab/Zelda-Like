using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboP2S1Neo : MonoBehaviour
{
    [SerializeField] private float time;
    private float timer;

    private void Awake()
    {
        timer = time;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            GameObject enemy = col.transform.parent.parent.gameObject;

            enemy.GetComponent<EnemyState>().TakeDamage(2);
        }
    }
}
