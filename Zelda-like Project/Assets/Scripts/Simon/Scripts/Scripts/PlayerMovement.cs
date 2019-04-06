using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject gameManager;

    private PlayerStats statsScript;

    private InputManager inputScript;

    public Vector2 direction { get; private set; }

    //private float direction2;
    //public float Direction2 { get { return direction2; } private set { direction2 = Mathf.Clamp(value, 0, 100); } }
    #endregion

    private void Awake()
    {

        inputScript = gameManager.GetComponent<InputManager>();

        statsScript = GetComponent<PlayerStatistics>().otherStats;

    }

    void Update()
    {

        Movement();

    }

    private void Movement()
    {

        if (inputScript.inputHor == 0 && inputScript.inputVer == 0) return;
        else
        {
            transform.Translate(inputScript.inputHor * Time.deltaTime * statsScript.movementSpeed, inputScript.inputVer * Time.deltaTime * statsScript.movementSpeed, 0);

            direction = new Vector2(inputScript.inputHor, inputScript.inputVer).normalized;
        }
    }

}
