using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private GameObject player;
    private HealthPlayer playerHealth;
    private Transform playerTransform;

    public GameObject enemyHealthBarPrefab;

    private GameObject enemyHealthBar;

    private EnemyHealthBar enemyHealthBarScript;

    [SerializeField] private float enemySpeed;

    private void Start()
    {

        player = GameObject.Find("Player");

        playerHealth = player.GetComponent<HealthPlayer>();
        playerTransform = player.GetComponent<Transform>();

        enemyHealthBar = Instantiate(enemyHealthBarPrefab, new Vector2(transform.position.x, transform.position.y +1), Quaternion.identity);

        enemyHealthBar.transform.parent = transform;

        enemyHealthBarScript = enemyHealthBar.GetComponent<EnemyHealthBar>();

    }

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, enemySpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("AttackMouse0"))
        {

            enemyHealthBarScript.Damaged();

        }

        if(other.CompareTag("Player"))
        {

            playerHealth.TakeDamage();

        }

    }

}
