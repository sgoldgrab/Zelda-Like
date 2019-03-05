using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDoubleTap : MonoBehaviour
{

    private bool ntm = false;

    private float timer = 0.2f;

    private bool oui = false;

    private void Update()
    {
        
        if(ntm)
        {

            timer -= Time.deltaTime;

        }

        if(Input.GetKeyDown(KeyCode.E) && !ntm)
        {

            ntm = true;       

        }

        if(Input.GetKeyDown(KeyCode.E) && ntm && timer > 0)
        {

            Debug.Log("DRINK");

            oui = true;

            ntm = false;

            timer = 0.2f;

        }

        else if(timer <= 0 && !oui && ntm)
        {

            Debug.Log("BLUEPRINT");

            ntm = false;

            timer = 0.2f;

        }

    }

}
