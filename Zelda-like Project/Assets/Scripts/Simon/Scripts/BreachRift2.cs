using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreachRift2 : MonoBehaviour
{
    public float score { get; set; } = 0;

    private void Update()
    {
        if (score >= 40) { Destroy(gameObject); }
    }
}
