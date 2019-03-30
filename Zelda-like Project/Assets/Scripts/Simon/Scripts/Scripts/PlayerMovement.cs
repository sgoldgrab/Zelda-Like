using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject gameManager;

    private PlayerStats statsScript;

    private InputManager inputScript;
    #endregion

    private void Awake()
    {

        inputScript = gameManager.GetComponent<InputManager>();

        statsScript = GetComponent<PlayerStatistics>().otherStats;

    }

    void Update()
    {

        {

            Movement();

        }
        
    }

    private void Movement()
    {

        transform.Translate(inputScript.inputHor * Time.deltaTime * statsScript.movementSpeed, inputScript.inputVer * Time.deltaTime * statsScript.movementSpeed, 0);

    }

}
