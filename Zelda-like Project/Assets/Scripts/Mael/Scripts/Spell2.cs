using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2 : MonoBehaviour
{
    
    //public float forceAmount;

    private Rigidbody2D rb;
    public float speed = 0.1f;
    Rigidbody2D rb2d;
    Vector3 fwd;

    private Transform player;
    private Vector2 target;



    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Templar").transform;

        target = new Vector2(player.position.x, player.position.y);

        rb2d = GetComponent<Rigidbody2D>();
        fwd = transform.TransformDirection(Vector3.up);

        transform.rotation = player.transform.rotation;

        StartCoroutine(TicTac());
        
    }
    private void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        Vector2 position = transform.position;
        position.x  += speed;
        transform.position = position;
    }



    IEnumerator TicTac()
    {
        
        yield return new WaitForSeconds(1);
      
        Destroy(gameObject);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Enemy")
        {

            //applique effet
            //rb.AddForce(transform.right * forceAmount, ForceMode2D.Impulse);


        }
        else
        {
            //se detruit contre murs/autres
        }
    }




}
