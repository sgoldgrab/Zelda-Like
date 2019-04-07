using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTestTamer : MonoBehaviour
{

    [TagSelector]
    public string TagFilter = "";                       

    [TagSelector]
    public string[] TagFilterArray = new string[] { };

}
