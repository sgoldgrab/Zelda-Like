
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SephirothsStock : MonoBehaviour
{

    [SerializeField] private Dictionary<string, GameObject> sephiroths;

    private AllSephiroths[] sephirothsScripts;

    private bool slot0Taken = false;
    private bool slot1Taken = false;
    private bool slot2Taken = false;
    private bool slot3Taken = false;

    private Malkuth malkuthScript;
    private Hod hodScript;
    private Yesod yesodScript;
    private Nezah nezahScript;
    private Gevurah gevurahScript;
    private Tipheret tipheretScript;
    private Hesed hesedScript;
    private Binah binahScript;
    private Kether ketherScript;
    private Hokhmah hokhmahScript;

    private PlayerState playerState;
    private PlayerAttack playerAttack;
    private PlayerAbilities playerAbilities;
    private PlayerMovement playerMovement;
    private PlayerSight playerSight;

    [SerializeField] private GameObject[] sephirothsInInventory = new GameObject[4];

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAbilities = GetComponent<PlayerAbilities>();
        playerMovement = GetComponent<PlayerMovement>();
        playerSight = GetComponent<PlayerSight>();
    }

    private void Update()
    {
        if (sephirothsInInventory[0] == sephiroths["Malkuth"] && !slot0Taken)
        {
            malkuthScript.isActive = true;
            slot0Taken = true;
        }
        if (sephirothsInInventory[1] == sephiroths["Hod"] && !slot1Taken)
        {
            hodScript.isActive = true;
            slot1Taken = true;
        }
        if (sephirothsInInventory[1] == sephiroths["Yesod"] && !slot1Taken)
        {
            yesodScript.isActive = true;
            slot1Taken = true;
        }
        if (sephirothsInInventory[1] == sephiroths["Nezah"] && !slot1Taken)
        {
            nezahScript.isActive = true;
            slot1Taken = true;
        }
        if (sephirothsInInventory[2] == sephiroths["Gevurah"] && !slot2Taken)
        {
            gevurahScript.isActive = true;
            slot2Taken = true;
        }
        if (sephirothsInInventory[2] == sephiroths["Tipheret"] && !slot2Taken)
        {
            tipheretScript.isActive = true;
            slot2Taken = true;
        }
        if (sephirothsInInventory[2] == sephiroths["Hesed"] && !slot2Taken)
        {
            hesedScript.isActive = true;
            slot2Taken = true;
        }
        if (sephirothsInInventory[3] == sephiroths["Binah"] && !slot3Taken)
        {
            binahScript.isActive = true;
            slot3Taken = true;
        }
        if (sephirothsInInventory[3] == sephiroths["Kether"] && !slot3Taken)
        {
            ketherScript.isActive = true;
            slot3Taken = true;
        }
        if (sephirothsInInventory[3] == sephiroths["Hokhmah"] && !slot3Taken)
        {
            hokhmahScript.isActive = true;
            slot3Taken = true;
        }
    }

}
