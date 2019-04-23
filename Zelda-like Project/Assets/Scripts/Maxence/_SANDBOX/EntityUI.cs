using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> healthSegs = new List<GameObject>();
    [SerializeField] private string segName;

    [SerializeField] private EntityState state;

    private void Start()
    {
        if (gameObject.tag == "Enemy") { state = GetComponentInParent<EntityState>(); }

        for (int n = 0; n < state.health; n++)
        {
            string theNameYouNeed = segName + " " + (n + 1).ToString();

            //healthSegs.Add(GameObject.Find(theNameYouNeed)); // fills the objects of the list with the health segs

            foreach (Transform child in transform)
            {
                if (child.name == theNameYouNeed)
                {
                    healthSegs.Add(child.gameObject);
                }
            }
        }
    }

    public void UITakeDamage(int currentHealth, int damageIndex)
    {
        int bonusDmg = 0;

        for (int x = 0; x < damageIndex; x++)
        {
            healthSegs[(currentHealth - 1) - bonusDmg].SetActive(false);
            bonusDmg++;
        }
    }

    public void UITakeHealth(int currentHealth, int healIndex)
    {
        int bonusHeal = 0;

        for (int x = 0; x < healIndex; x++)
        {
            healthSegs[currentHealth + bonusHeal].SetActive(true);
            bonusHeal++;
        }
    }
}
