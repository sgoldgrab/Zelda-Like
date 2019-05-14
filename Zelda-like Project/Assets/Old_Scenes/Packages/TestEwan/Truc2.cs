using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truc2 : MonoBehaviour
{
    private int truc;
    public int Truc => truc;

    public void Update()
    {
        if(Time.frameCount % 60 == 0)
        {
            truc = Random.Range(1, 100);
        }
    }
}
