using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audiMixer;

    public void SetVolume (float volume)
    {
        audiMixer.SetFloat("MainVolume", volume);
    }
}
