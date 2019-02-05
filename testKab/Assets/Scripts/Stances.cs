using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stances : MonoBehaviour
{

    public bool stanceOne = true;
    private Color colorOne = new Color(255, 0, 0);
    private Color colorTwo = new Color(0, 0, 255);

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchStances();
        }
    }

    private void SwitchStances()
    {
        if(stanceOne)
        {
            stanceOne = false;
            sprite.color = colorTwo;
        }

        else if(!stanceOne)
        {
            stanceOne = true;
            sprite.color = colorOne;
        }
    }

}
