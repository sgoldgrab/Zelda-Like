using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SephirothsStock : MonoBehaviour
{
    [SerializeField] private Dictionary<string, GameObject> sephirothsDictionary;

    private bool slot0Taken = false;
    private bool slot1Taken = false;
    private bool slot2Taken = false;
    private bool slot3Taken = false;

    public List<GameObject> sephirothsInInventory = new List<GameObject>(4);

    private void Update()
    {
        if (sephirothsInInventory.Count <= 0) return;

        if (sephirothsInInventory[0] == sephirothsDictionary["Malkuth"] && !slot0Taken)
        {
            Malkuth malkuthScript = sephirothsInInventory[0].GetComponent<Malkuth>();
            malkuthScript.isActive = true;
            slot0Taken = true;
        }
        if (sephirothsInInventory[1] == sephirothsDictionary["Hod"] && !slot1Taken)
        {
            Hod hodScript = sephirothsInInventory[1].GetComponent<Hod>();
            hodScript.isActive = true;
            slot1Taken = true;
        }
        if (sephirothsInInventory[1] == sephirothsDictionary["Yesod"] && !slot1Taken)
        {
            Yesod yesodScript = sephirothsInInventory[1].GetComponent<Yesod>();
            yesodScript.isActive = true;
            slot1Taken = true;
        }
        if (sephirothsInInventory[1] == sephirothsDictionary["Nezah"] && !slot1Taken)
        {
            Nezah nezahScript = sephirothsInInventory[1].GetComponent<Nezah>();
            nezahScript.isActive = true;
            slot1Taken = true;
        }
        if (sephirothsInInventory[2] == sephirothsDictionary["Gevurah"] && !slot2Taken)
        {
            Gevurah gevurahScript = sephirothsInInventory[2].GetComponent<Gevurah>();
            gevurahScript.isActive = true;
            slot2Taken = true;
        }
        if (sephirothsInInventory[2] == sephirothsDictionary["Tipheret"] && !slot2Taken)
        {
            Tipheret tipheretScript = sephirothsInInventory[2].GetComponent<Tipheret>();
            tipheretScript.isActive = true;
            slot2Taken = true;
        }
        if (sephirothsInInventory[2] == sephirothsDictionary["Hesed"] && !slot2Taken)
        {
            Hesed hesedScript = sephirothsInInventory[2].GetComponent<Hesed>();
            hesedScript.isActive = true;
            slot2Taken = true;
        }
        if (sephirothsInInventory[3] == sephirothsDictionary["Binah"] && !slot3Taken)
        {
            Binah binahScript = sephirothsInInventory[3].GetComponent<Binah>();
            binahScript.isActive = true;
            slot3Taken = true;
        }
        if (sephirothsInInventory[3] == sephirothsDictionary["Kether"] && !slot3Taken)
        {
            Kether ketherScript = sephirothsInInventory[3].GetComponent<Kether>();
            ketherScript.isActive = true;
            slot3Taken = true;
        }
        if (sephirothsInInventory[3] == sephirothsDictionary["Hokhmah"] && !slot3Taken)
        {
            Hokhmah hokhmahScript = sephirothsInInventory[3].GetComponent<Hokhmah>();
            hokhmahScript.isActive = true;
            slot3Taken = true;
        }
    }
}
