    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    public bool isInRangeToInteract = false;

    public void Interacting()
    {

        if(isInRangeToInteract)
        {

            Debug.Log("OUIBIENSUR");

        }

    }

}
