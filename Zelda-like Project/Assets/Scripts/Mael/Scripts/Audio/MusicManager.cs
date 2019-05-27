using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField] private string jerusalemMusicName;
    [SerializeField] private string bossMusicName;

    [SerializeField] private Teleporter teleporter;

    void Start()
    {
        audioManager = AudioManager.instance;

        audioManager.PlaySound(jerusalemMusicName);
    }

    void Update()
    {
        if (teleporter.readyForBossMusic)
        {
            audioManager.StopSound(jerusalemMusicName);

            audioManager.PlaySound(bossMusicName);
        }
    }
}
