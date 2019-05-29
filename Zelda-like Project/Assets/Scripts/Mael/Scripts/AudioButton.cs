using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField]
    string buttonSelectedSound;
    [SerializeField]
    string buttonPressedSound;


    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioManager = AudioManager.instance;
    }



    public void OnSelect(BaseEventData eventData)
    {
        audioManager.PlaySound("ButtonSelected");
        Debug.Log("BBBB");
    }

    public void ButtonPressed()
    {
        audioManager.PlaySound("ButtonClicked");
    }

}




