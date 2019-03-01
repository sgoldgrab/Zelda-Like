using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell3 : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;
    Vector3 fwd;

    private Transform enemy;
    private Vector2 target;

    public Vector2 currentPos;

    private DormantEnemy DorEnemy;


    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;

        target = new Vector2(enemy.position.x, enemy.position.y);

        rb2d = GetComponent<Rigidbody2D>();
        fwd = transform.TransformDirection(Vector3.up);

        DorEnemy = GetComponent<DormantEnemy>();

        StartCoroutine(TicTac());
    }

    IEnumerator TicTac()
    {

        yield return new WaitForSeconds(2);

        Destroy(gameObject);

    }

    private void Update()
    {
        transform.position += transform.up * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            //other.GetComponent("DormantEnemy") as Spell1Effect.function();


        }
        else
        {
            //se detruit contre murs/autres
            
        }
    }

    
}
