using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDirection : MonoBehaviour
{

    private void Update()
    {

        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") > 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, 90);

        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") < 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, -90);

        }

        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") == 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);

        }

        if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") == 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, -180);

        }

        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, 45);

        }

        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, -45);

        }

        if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, 135);

        }

        if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, -135);

        }

    }

}
