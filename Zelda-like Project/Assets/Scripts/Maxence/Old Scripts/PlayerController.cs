using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Animator playerAnimator;
    private float dirX;
    private float dirY;
    private int intDirection;
    public Transform attackPosition;
	
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        GetComponent<PlayerAttack>().pos = 0;
    }

    void Update()
    {
        //Vector2 attackPositionRelative = attackPosition.InverseTransformPoint(transform.position);
        //Debug.Log(attackPositionRelative);

        PlayerDirection();

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        if (Input.anyKey == false)
        {
            playerAnimator.SetInteger("movingPosition", 0);
        }
    }

    void PlayerDirection()
    {
        dirX = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        dirY = Mathf.RoundToInt(Input.GetAxis("Vertical"));

        //Debug.Log(dirX + " " + dirY);

        //up
        if (dirX == 0 && dirY == 1)
        {
            playerAnimator.SetInteger("movingPosition", 1);
            GetComponent<PlayerAttack>().pos = 1;
            //attackPosition.position = new Vector2(0.0f, 1.15f);
            intDirection = 1;
        }

        //down
        else if (dirX == 0 && dirY == -1)
        {
            playerAnimator.SetInteger("movingPosition", 2);
            GetComponent<PlayerAttack>().pos = 0;
            intDirection = 2;
        }

        //right
        else if (dirX == 1 && dirY == 0)
        {
            playerAnimator.SetInteger("movingPosition", 3);
            GetComponent<PlayerAttack>().pos = 2;
            intDirection = 3;
        }

        //left
        else if (dirX == -1 && dirY == 0)
        {
            playerAnimator.SetInteger("movingPosition", 4);
            GetComponent<PlayerAttack>().pos = 3;
            intDirection = 4;
        }

        //upRight
        else if (dirX == 1 && dirY == 1)
        {
            playerAnimator.SetInteger("movingPosition", 5);
            GetComponent<PlayerAttack>().pos = 4;
            intDirection = 5;
        }

        //downRight
        else if (dirX == 1 && dirY == -1)
        {
            playerAnimator.SetInteger("movingPosition", 6);
            GetComponent<PlayerAttack>().pos = 5;
            intDirection = 6;
        }

        //downLeft
        else if (dirX == -1 && dirY == -1)
        {
            playerAnimator.SetInteger("movingPosition", 7);
            GetComponent<PlayerAttack>().pos = 6;
            intDirection = 7;
        }

        //upLeft
        else if (dirX == -1 && dirY == 1)
        {
            playerAnimator.SetInteger("movingPosition", 8);
            GetComponent<PlayerAttack>().pos = 7;
            intDirection = 8;
        }

        //STOP AND IDLE
        else if(dirX == 0 && dirY == 0)
        {
            playerAnimator.SetInteger("movingPosition", 0);
        }
    }
}
