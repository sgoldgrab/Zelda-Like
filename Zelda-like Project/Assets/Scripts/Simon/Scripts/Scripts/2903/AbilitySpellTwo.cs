using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySpellTwo : MonoBehaviour
{
    #region Variables
    private Rigidbody2D targetrb2D;

    private bool enemyHit = false;

    [SerializeField] private float timer;

    [SerializeField] private int forceAmount;

    [SerializeField] private Vector2 direction;
    #endregion

    private void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {

            if(enemyHit)
            {

                targetrb2D.AddForce(direction * forceAmount * -1);

                Destroy(gameObject);

            }

            else if (!enemyHit)
            {

                Destroy(gameObject);

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        
        if(enemy.CompareTag("Enemy"))
        {

            enemyHit = true;

            targetrb2D = enemy.GetComponent<Rigidbody2D>();

            targetrb2D.AddForce(direction * forceAmount);

        }

    }

    public void SetDirection(Vector2 _direction)
    {
        direction = _direction;
    }

}
