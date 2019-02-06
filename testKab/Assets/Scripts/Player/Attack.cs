using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public GameObject attackBluePrint;

    private float timer;

    private Movements movementScript;

    private void Start()
    {

        movementScript = GetComponent<Movements>();

    }

    private void Update()
    {

        timer -= Time.deltaTime;

        Inputs();

    }

    private void Inputs()
    {

        if(Input.GetKeyDown(KeyCode.Space) && timer <=0)
        {

            Attacking();

        }

    }

    private void Attacking()
    {

        Instantiate(attackBluePrint, transform.position, Quaternion.Euler(movementScript.lastInput));
        timer = 0.5f;

    }

}
