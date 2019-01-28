using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

    public Vector2 sensDuVent;

    public bool changeWind = false;

    private void Update()
    {
        if(!changeWind)
        {
            sensDuVent = new Vector2(0, 0.5f);
        }

        else if(changeWind)
        {
            sensDuVent = new Vector2(0, -0.5f);
        }
    }

}
