using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySpellTwo : MonoBehaviour
{

    private Rigidbody2D targetrb2D;

    [SerializeField] private float timer;

    private void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {

            Destroy(this.gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        
        if(enemy.CompareTag("Enemy"))
        {

            targetrb2D = enemy.GetComponent<Rigidbody2D>();

            Debug.Log("OUI");

            targetrb2D.AddForce(Vector2.up); //remplacer Vector2 par la bonne direction

        }

    }

}
