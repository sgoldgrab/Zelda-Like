using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesUIManagement : MonoBehaviour
{

    //s'active lorsqu'une abilty est cast
    public Image PotionUI1;
    public Image PotionUI2;

    //le temps du fill de l'image pour qu'il correspond à l'abilité
    public float cooldownPotionUI1;
    public float cooldownPotionUI2;

    //pour savoir si elle est en cooldown ou non. Du coup c'est provisoire
    bool isPotion1Cooldown;
    bool isPotion2Cooldown;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isPotion1Cooldown)
        {
            isPotion1Cooldown = true;
            PotionUI1.fillAmount = 1;
            CooldownUI();
        }

        if (isPotion1Cooldown)
        {
           if (PotionUI1.fillAmount <= 0)
            {
                //StopCoroutine("CooldownUI");
                isPotion1Cooldown = false;
            }
           else
            {
                CooldownUI();
            }
        }
        /*if (Input.GetKeyDown(KeyCode.Alpha2) && !isPotion2Cooldown)
        {
            isPotion2Cooldown = true;
            
        }

        if (isPotion2Cooldown)
        {
            PotionUI2.fillAmount += 1 / cooldownPotionUI2 * Time.deltaTime;

            if (PotionUI1.fillAmount <= 0)
            {
                //StopCoroutine("CooldownUI");
                isPotion2Cooldown = false;
            }
            if (PotionUI2.fillAmount >= 1)
            {
                PotionUI2.fillAmount = 0;
                isPotion2Cooldown = false;
            }
        }*/

    }

    void CooldownUI()
    {
        PotionUI1.fillAmount -= 1 / cooldownPotionUI1 * Time.deltaTime;
       
    }
}
