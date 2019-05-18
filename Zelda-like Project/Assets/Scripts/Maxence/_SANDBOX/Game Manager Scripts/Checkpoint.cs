using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Respawn respawn;

    void Start()
    {
        respawn = GameObject.Find("Respawn").GetComponent<Respawn>();
    }

    void OnTriggerEnter2D()
    {
        respawn.checkPoint = true;
        respawn.checkPointSpawn = gameObject;
    }
}
