using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownManagerUI : MonoBehaviour
{
    public Image spell1Cooldown;

    public float cooldown = 5;
    bool isCooldown;

    [SerializeField] private PlayerAbilities playerAbilities;
    [SerializeField] private int index;

    void Update()
    {
        if (!playerAbilities.notCooldown[index])
        {
            isCooldown = true;
        }

        if (isCooldown)
        {
            spell1Cooldown.fillAmount += 1 / cooldown * Time.deltaTime;

            if (spell1Cooldown.fillAmount >= 1)
            {
                spell1Cooldown.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
