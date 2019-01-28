using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{

    public GameObject ice;

    public void OnMouseDown()
    {
        Instantiate(ice, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
