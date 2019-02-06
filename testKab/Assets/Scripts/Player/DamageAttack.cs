using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAttack : MonoBehaviour
{

    private float timer;

    private GameObject player;
    private Movements playerMovements;

    private void Start()
    {

        player = GameObject.Find("Player");

        playerMovements = player.GetComponent<Movements>();

        transform.LookAt(new Vector3(playerMovements.lastInput.x, playerMovements.lastInput.y, 0));

        this.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z);

        timer = 0.1f;

    }

    private void Update()
    {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {

            Destroy(this.gameObject);

        }

    }

}
