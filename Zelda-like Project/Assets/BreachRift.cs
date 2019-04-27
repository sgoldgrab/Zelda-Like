using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreachRift : MonoBehaviour
{

    public float score = 0;

    private void Update()
    {
        
        if(score >= 40)
        {

            Destroy(this);

        }

    }

}
