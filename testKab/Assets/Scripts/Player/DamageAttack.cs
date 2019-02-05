using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAttack : MonoBehaviour
{

    private float timer;

    private void Start()
    {

        timer = 0.1f;

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
