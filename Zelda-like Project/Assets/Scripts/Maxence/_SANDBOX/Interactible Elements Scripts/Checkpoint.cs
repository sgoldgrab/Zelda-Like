using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GlobalData globalData;

    void Start()
    {
        globalData = GameObject.Find("DATA").GetComponent<GlobalData>();
    }

    void OnTriggerEnter2D()
    {
        globalData.checkpointPos = transform.position;
    }
}
