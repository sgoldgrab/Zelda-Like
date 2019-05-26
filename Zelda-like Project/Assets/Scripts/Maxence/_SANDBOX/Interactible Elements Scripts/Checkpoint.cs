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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") globalData.checkpointPos = transform.position;
    }
}
