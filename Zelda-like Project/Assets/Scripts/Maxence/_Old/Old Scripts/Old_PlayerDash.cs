using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_PlayerDash : MonoBehaviour {

    private PlayerControllerEzEz playerController;

    private float dashHorizontal;
    private float dashVertical;

    //private Vector2 mousePos;

    [SerializeField] private float dashDistance;
    [SerializeField] private float dashSpeed;

    void Start ()
    {
        playerController = GetComponent<PlayerControllerEzEz>();
	}
	
	void Update ()
    {
        Dash();
    }

    void Dash()
    {
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dashDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 dashMovement = dashDirection * dashDistance;

        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position = Vector2.MoveTowards(transform.position, dashMovement, dashSpeed * Time.deltaTime);
        }
    }

    void OldDash()
    {
        dashHorizontal = playerController.horizontal;
        dashVertical = playerController.vertical;

        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.Translate(dashHorizontal * dashSpeed * Time.deltaTime, dashVertical * dashSpeed * Time.deltaTime, 0);
        }
    }
}
