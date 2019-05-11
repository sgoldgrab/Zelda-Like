using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject templarPrefab;
    [SerializeField] private GameObject arabPrefab;
    [SerializeField] private GameObject angelPrefab;
    [SerializeField] private GameObject demonPrefab;
    [SerializeField] private GameObject kabbalistPrefab;

    [SerializeField] private GameObject iris;
    [SerializeField] private GameObject dust;
    [SerializeField] private GameObject crystal;
    [SerializeField] private GameObject lily;
    [SerializeField] private GameObject locket;
    [SerializeField] private GameObject charm;

    private void Awake()
    {
        Set();
    }

    public void Set()
    {
        //fait pop les ennemis et consommables et interactables
    }

    public void Reset()
    {
        GameObject[] consumables = GameObject.FindGameObjectsWithTag("Consumables");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactables");

        for (int j = 0; j < interactables.Length; j++)
        {
            Destroy(interactables[j]);
        }

        for (int i = 0; i < consumables.Length; i++)
        {
            Destroy(consumables[i]);
        }

        for (int k = 0; k < enemies.Length; k++)
        {
            Destroy(enemies[k]);
        }
    }

}
