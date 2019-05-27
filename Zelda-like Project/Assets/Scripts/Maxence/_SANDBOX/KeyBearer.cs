using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBearer : MonoBehaviour
{
    [SerializeField] private GameObject key;

    private EnemyState enemyState;

    void Start()
    {
        enemyState = GetComponent<EnemyState>();
    }

    void Update()
    {
        if (enemyState.health <= 0) Instantiate(key, transform.position, transform.rotation);
    }
}
