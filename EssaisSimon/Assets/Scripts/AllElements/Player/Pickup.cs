using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public GameObject displayStone;
    private bool holdStone = false;
    private GameObject theStone;

    private Vector3 mousePosition;
    private Vector2 distance;

    private void Start()
    {
        displayStone.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Pickup")
        {
            displayStone.SetActive(true);
            holdStone = true;
            other.gameObject.SetActive(false);

            theStone = other.gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && holdStone)
        {
            displayStone.SetActive(false);
            holdStone = false;

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            theStone.transform.position = mousePosition;
            theStone.SetActive(true);
        }
    }
}
