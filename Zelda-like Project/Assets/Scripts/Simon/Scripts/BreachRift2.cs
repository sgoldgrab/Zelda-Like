using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreachRift2 : MonoBehaviour
{
    public float scoreUseless = 0;

    [SerializeField] private float score;

    [SerializeField] private GameObject area1;
    [SerializeField] private GameObject area2;
    [SerializeField] private GameObject area3;
    [SerializeField] private GameObject area4;

    [SerializeField] private GameObject keyPrefab;

    [SerializeField] private GameObject altar2;

    private void Update()
    {
        if (scoreUseless >= score)
        {
            area1.GetComponent<BreachArea>().isActive = false;
            area2.GetComponent<BreachArea>().isActive = false;
            area3.GetComponent<BreachArea>().isActive = false;
            area4.GetComponent<BreachArea>().isActive = false;

            Instantiate(keyPrefab, transform.position, transform.rotation);

            altar2.GetComponentInChildren<AltarTestSandbox>().locked = false;

            Destroy(gameObject);
        }
    }
}
