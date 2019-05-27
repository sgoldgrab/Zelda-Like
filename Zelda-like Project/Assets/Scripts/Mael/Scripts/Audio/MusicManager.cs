using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField] private string jerusalemMusicName;
    [SerializeField] private string bossMusicName;

    [SerializeField] private Teleporter teleporter;

    //NEW
    [SerializeField] private List<AudioSource> audioSources;

    void Start()
    {
        //audioManager = AudioManager.instance;

        //audioManager.PlaySound(jerusalemMusicName);
        audioSources[0].Play();
    }

    void Update()
    {
        /*
        Debug.Log(audioManager.theSounds[1].clip.loadState);
        Debug.Log(audioManager.theSounds[0].clip.loadState);
        */

        if (teleporter.readyForBossMusic)
        {

            //StartCoroutine(SwitchMusic());
            
        }
    }

    IEnumerator SwitchMusic()
    {
        //audioManager.StopSound(jerusalemMusicName);
        audioSources[0].Stop();

        yield return new WaitForSeconds(0.5f);

        //audioManager.PlaySound(bossMusicName);
        audioSources[1].Play();
    }
}
