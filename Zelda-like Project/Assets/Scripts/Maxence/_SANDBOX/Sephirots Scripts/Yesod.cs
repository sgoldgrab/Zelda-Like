using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yesod : Sephiroth
{
    private GameObject player;
    private Animator playerAnimator;

    private void Awake()
    {
        player = GameObject.Find("PLAYER");
        playerAnimator = player.GetComponentInChildren<Animator>();
    }

    public override void Activation()
    {
        if (isActive && !effect)
        {
            playerAnimator.SetFloat("speedAnim", 1.5f);
            effect = true;
        }

        base.Activation();
    }

}
