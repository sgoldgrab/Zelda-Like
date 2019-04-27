using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStance : MonoBehaviour
{
    [SerializeField] private string stanceInput;
    public string input { get => stanceInput; private set => stanceInput = value; }

    public enum Stance { stance1, stance2 };
    public Stance whatStance { get; private set; } = Stance.stance1;

    public bool canSwitch { get; set; } = true;

    [SerializeField] private GameObject postProcess;

    void Update()
    {
        if (Input.GetButtonDown(stanceInput) && canSwitch)
        {
            if (whatStance == Stance.stance1) //switch to stance 2
            {
                whatStance = Stance.stance2;

                postProcess.SetActive(true);
            }

            else if (whatStance == Stance.stance2) // switch to stance 1
            {
                whatStance = Stance.stance1;

                postProcess.SetActive(false);
            }
        }
    }
}
