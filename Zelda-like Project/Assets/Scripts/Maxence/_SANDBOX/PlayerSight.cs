using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    [SerializeField] private Sprite[] fogs;
    [SerializeField] private Sprite[] mists;

    private SpriteRenderer theFog;
    private SpriteRenderer theMist;

    public bool aware { get; set; }

    void Start()
    {
        theFog = GameObject.Find("Fog").GetComponent<SpriteRenderer>();
        theMist = GameObject.Find("Mist").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (aware)
        {
            theFog.sprite = fogs[1];
            theMist.sprite = mists[1];
        }

        else
        {
            theFog.sprite = fogs[0];
            theMist.sprite = mists[0];
        }
    }
}
