using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public GameObject attackBluePrint;

    private float timer;

    private Vector3 direction;

    private void Update()
    {

        timer -= Time.deltaTime;

        Inputs();

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    private void Inputs()
    {

        if(Input.GetKeyDown(KeyCode.Mouse0) && timer <=0)
        {

            Attacking();

        }

    }

    private void Attacking()
    {

        Instantiate(attackBluePrint, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(direction));
        timer = 0.5f;

    }

}
