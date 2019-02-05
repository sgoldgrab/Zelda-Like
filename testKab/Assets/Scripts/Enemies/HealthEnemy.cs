using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{

    [SerializeField]
    private int health = 10;

    public GameObject player;
    private HealthPlayer playerHealth;

    public GameObject healthBarPrefab;
    private Slider barSlider;

    [SerializeField]
    private Transform canvasTransform;

    private void Start()
    {

        playerHealth = player.GetComponent<HealthPlayer>();

        GameObject healthBar = Instantiate(healthBarPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);

        healthBar.transform.parent = canvasTransform;

        barSlider = healthBar.GetComponent<Slider>();

    }

    private void Update()
    {

        barSlider.value = health;

        if (health <= 0)
        {

            Destroy(this.gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("AttackMouse0"))
        {

            health -= 4;

        }

        if(other.CompareTag("Player"))
        {

            playerHealth.health -= 8;

        }

    }

}
