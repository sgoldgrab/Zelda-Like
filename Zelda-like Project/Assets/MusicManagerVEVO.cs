using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerVEVO : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField] private string JerusalemMusic;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        audioManager.PlaySound("JeruLoopMusic");
    }
}
