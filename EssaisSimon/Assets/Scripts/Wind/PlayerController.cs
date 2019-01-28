using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject wind;
    private Wind windScript;

    private void Start()
    {
        windScript = wind.GetComponent<Wind>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeWind();
        }
    }

    private void ChangeWind()
    {
        if(!windScript.changeWind)
        {
            windScript.changeWind = true;
        }

        else if(windScript.changeWind)
        {
            windScript.changeWind = false;
        }
    }

}
