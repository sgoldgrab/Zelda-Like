using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;

    private AudioManager audioManager;

    [SerializeField] private string JeruStop;
    [SerializeField] private string BossIntroMusicStart;

    private void Start()
    {
        audioManager = AudioManager.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.transform.parent.parent.gameObject;

            player.transform.position = destination.position;

            audioManager.StopSound("JeruLoopMusic");
            audioManager.PlaySound("BossIntroMusic");
        }
    }
}
