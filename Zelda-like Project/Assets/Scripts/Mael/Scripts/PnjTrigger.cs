using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public GameObject buttonPnj;

    private void Start()
    {
        buttonPnj.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            //dialogue.Dialogue1();
            buttonPnj.SetActive(true);
        }
    }

    public void DisplayDialogue1()
    {
        dialogue.Dialogue1();

        buttonPnj.SetActive(false);
    }
}
