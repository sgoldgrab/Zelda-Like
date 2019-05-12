using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityEwan : MonoBehaviour
{

    private float timer = 1.7f;

    private void Update()
    {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {

            Destroy(this.gameObject);

        }

    }

}
