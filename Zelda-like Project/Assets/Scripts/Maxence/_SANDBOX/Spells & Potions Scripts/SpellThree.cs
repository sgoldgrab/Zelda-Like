using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellThree : MonoBehaviour
{
    private Transform playerPos;

    private void Start()
    {
        GameObject playerPosMessenger = GameObject.FindWithTag("Player");

        if(playerPosMessenger != null)
        {
            playerPos = playerPosMessenger.GetComponent<Transform>();
        }

        Teleport();
    }

    void Update()
    {
        StartCoroutine(Die());
    }

    void Teleport()
    {
        playerPos.position = transform.position;
    }

    IEnumerator Die()
    {        
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
