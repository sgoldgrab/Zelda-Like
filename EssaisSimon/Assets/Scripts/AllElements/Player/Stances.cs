using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stances : MonoBehaviour
{

    public bool stanceOne = true;

    private SpriteRenderer sprite;
    private Color stanceOneColor;
    private Color stanceTwoColor;

    private Movement movement;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        stanceOneColor = new Color(255, 0, 0);
        stanceTwoColor = new Color(0, 0, 255);
        sprite.color = stanceOneColor;

        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !movement.isDead)
        {
            SwitchStances();
        }
    }

    private void SwitchStances()
    {
        if (stanceOne)
        {
            sprite.color = stanceTwoColor;
            stanceOne = false;
        }

        else if (!stanceOne)
        {
            sprite.color = stanceOneColor;
            stanceOne = true;
        }
    }

}
