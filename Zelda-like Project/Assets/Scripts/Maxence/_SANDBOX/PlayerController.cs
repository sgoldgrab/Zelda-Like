using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    [SerializeField] private string stanceInput;
    [SerializeField] private string attackInput;

    [SerializeField] private string[] abilitiesInputs;

    private string abilityButtonName;

    private PlayerStance playerStance;

    void Update()
    {
        MoveInputs();

        if (Input.GetButtonDown(stanceInput))
        {

        }

        if (Input.GetButtonDown(attackInput))
        {

        }

        AbilitiesInputs();
    }

    void MoveInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void AbilitiesInputs()
    {
        if (playerStance.whatStance == PlayerStance.Stance.stance1)
        {
            if (Input.GetButtonDown(abilitiesInputs[0]))
            {

            }

            if (Input.GetButtonDown(abilitiesInputs[1]))
            {

            }

            if (Input.GetButtonDown(abilitiesInputs[2]))
            {

            }

            //if (inputPressed)
        }

        else if (playerStance.whatStance == PlayerStance.Stance.stance2)
        {
            if (Input.GetButtonDown(abilitiesInputs[0]))
            {

            }

            if (Input.GetButtonDown(abilitiesInputs[1]))
            {

            }

            if (Input.GetButtonDown(abilitiesInputs[2]))
            {

            }

            //if (inputPressed)
        }
    }
}
