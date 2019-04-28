using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1 : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;
    Vector3 fwd;

    


    public Vector2 currentPos;

    public DormantEnemy dormantEnemy;


    private void Start()
    {




        rb2d = GetComponent<Rigidbody2D>();
        fwd = transform.TransformDirection(Vector3.up);



        StartCoroutine(TicTac());
    }

    IEnumerator TicTac()
    {

        yield return new WaitForSeconds(2);

        Destroy(gameObject);

    }

    public void Update()
    {
        transform.position += transform.up * Time.deltaTime;
        
    }
    


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyHitBox")
        {
            print("Enemy touched");
            
            
            
            dormantEnemy = other.GetComponent<DormantEnemy>();
            dormantEnemy.Spell1Effect();
            Destroy(gameObject);
            
            //other.GetComponent<DormantEnemy>();
            //GameObject dormantEnemy = other.GetComponent<DormantEnemy>();
             //dormantEnemy.Spell1Effect();
            //DormantEnemy dormantEnemy = gameObject.GetComponent<DormantEnemy>();



            

        }
        else
        {
            //se detruit contre murs/autres
            
        }
    }
    


}
