using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAttack : MonoBehaviour
{

    private GameObject arrow;
    private Movements movementScript;

    private float timer;

    private void Start()
    {

        timer = 0.1f;

        arrow = GameObject.Find("arrow");
    
        transform.rotation = arrow.transform.rotation;

    }

    private void Update()
    {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {

            Destroy(this.gameObject);

        }

    }

}
