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
        if(invisibleStanceOne && stanceScript.whatStance == PlayerStance.Stance.stanceOne)
        {

            sprite.enabled = false;

        }


        if (invisibleStanceTwo && stanceScript.whatStance == PlayerStance.Stance.stanceOne)
        {

            sprite.enabled = true;

        }
        #endregion

        #region Invisible stance 2
        if (invisibleStanceTwo && stanceScript.whatStance == PlayerStance.Stance.stanceTwo)
        {

            sprite.enabled = false;

        }

        if (invisibleStanceOne && stanceScript.whatStance == PlayerStance.Stance.stanceTwo)
        {

            sprite.enabled = true;

        }
        #endregion

    }

}
