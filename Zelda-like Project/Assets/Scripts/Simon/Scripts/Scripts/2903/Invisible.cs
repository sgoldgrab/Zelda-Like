using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    #region Variables
    [SerializeField] private bool invisibleStanceOne;
    [SerializeField] private bool invisibleStanceTwo;

    private SpriteRenderer sprite;

    private PlayerStance stanceScript;

    [SerializeField] private GameObject player;
    #endregion

    private void Awake()
    {

        stanceScript = player.GetComponent<PlayerStance>();

        sprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        #region Invisible stance 1
        if(invisibleStanceOne && stanceScript.whatStance == PlayerStance.Stance.stance1)
        {

            sprite.enabled = false;

        }


        if (invisibleStanceTwo && stanceScript.whatStance == PlayerStance.Stance.stance1)
        {

            sprite.enabled = true;

        }
        #endregion

        #region Invisible stance 2
        if (invisibleStanceTwo && stanceScript.whatStance == PlayerStance.Stance.stance2)
        {

            sprite.enabled = false;

        }

        if (invisibleStanceOne && stanceScript.whatStance == PlayerStance.Stance.stance2)
        {

            sprite.enabled = true;

        }
        #endregion

    }

}
