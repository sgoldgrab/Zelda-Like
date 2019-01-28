using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{

    public GameObject fire;

    public void OnMouseDown()
    {
        Instantiate(fire, transform.position, Quaternion.identity);
    }

}

