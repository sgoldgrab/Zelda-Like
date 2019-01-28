using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{

    public GameObject projectile;
    public GameObject blueprint;

    private Vector2 direction;

    [SerializeField]
    private float cooldown;

    private float timer;

    private void Start()
    {

        timer = cooldown;

    }

    private void Update()
    {

        timer -= Time.deltaTime;

        GetInputs();

    }

    private void GetInputs()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1) && timer <= 0)
        {

            Debug.Log("Simple Tap");
            //instantiate prefab vers Vector2 direction
            timer = cooldown;

        }

        if(Input.GetKey(KeyCode.Alpha1) && timer <= 0)
        {

            Debug.Log("Hold");
            //instantiate blueprint

        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {

            Debug.Log("Release");
            //destroy blueprint
            //instantiate prefab
            timer = cooldown;

        }

    }

}
