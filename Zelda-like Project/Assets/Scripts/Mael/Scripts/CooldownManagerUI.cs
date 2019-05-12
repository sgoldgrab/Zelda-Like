using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownManagerUI : MonoBehaviour
{
    public Image spell1Cooldown;

    public float cooldown = 5;
    bool isCooldown;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
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
