using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindActive : MonoBehaviour
{

    private Rigidbody2D rb2D;

    public GameObject wind;
    private Wind windScript;

    private void Start()
    {
        windScript = wind.GetComponent<Wind>();

        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb2D.AddForce(windScript.sensDuVent);
    }

}
