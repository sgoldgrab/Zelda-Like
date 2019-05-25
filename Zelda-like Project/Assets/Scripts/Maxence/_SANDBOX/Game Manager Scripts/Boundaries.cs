using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [SerializeField] private BossFightSpawner bossFightSpawner;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            GameObject guy = other.transform.parent.parent.gameObject;

            guy.transform.position = bossFightSpawner.wannaSpawn[Random.Range(0, bossFightSpawner.wannaSpawn.Count)].position;
        }
    }
}
