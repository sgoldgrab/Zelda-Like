using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{

    [SerializeField]
    private int health = 10;

    private GameObject player;
    private HealthPlayer playerHealth;

    public GameObject healthBarPrefab;
    private GameObject healthBar;
    private Slider barSlider;

    private GameObject canvas;

    private void Start()
    {

        player = GameObject.Find("Player");

        playerHealth = player.GetComponent<HealthPlayer>();

        healthBar = Instantiate(healthBarPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);

        canvas = GameObject.Find("Canvas");

        healthBar.transform.parent = canvas.transform;

        barSlider = healthBar.GetComponent<Slider>();

    }

    private void Update()
    {

        barSlider.value = health;

        if (health <= 0)
        {

            Destroy(this.gameObject);
            Destroy(healthBar.gameObject);

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
