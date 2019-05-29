using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerVEVO : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField] private string JerusalemMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;

        audioManager.PlaySound("JeruLoopMusic");
    }

}
