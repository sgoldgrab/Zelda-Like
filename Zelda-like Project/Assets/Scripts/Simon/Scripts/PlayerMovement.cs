using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject gameManager;

    private InputManager inputScript;
    #endregion

    private void Awake()
    {

        inputScript = gameManager.GetComponent<InputManager>();

    }

    void Update()
    {

        Movement();
        
    }

    private void Movement()
    {

        transform.Translate(inputScript.inputHor * Time.deltaTime, inputScript.inputVer * Time.deltaTime, 0);

    }

}
