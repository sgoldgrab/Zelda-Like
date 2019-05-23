using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownManagerUI : MonoBehaviour
{
    public Image spell1Cooldown;

    [SerializeField] private int index;
    [SerializeField] private PlayerAbilities playerAbilities;
    bool isCooldown;

    void Update()
    {
        //spell1Cooldown.fillAmount = 1 - (playerAbilities.coolDownTime[index] / 2);
    }
}
