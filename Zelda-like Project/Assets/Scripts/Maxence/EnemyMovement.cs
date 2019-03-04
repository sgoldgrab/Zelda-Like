using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private RandomEnemyBehavior enemyBehavior;
    private Vector2 checkpoint;
    private Vector2 desiredPosition;
    private float waitTime = 0;
    private float waitDistantTime = 0;
    private bool lockDistantBool;

    public float enemySpeed;
    public float safeSpace;
    public Transform playerPos;
    public float desiredDistance;

    [SerializeField]
    private float startWaitTime;
    [SerializeField]
    private float startWaitDistantTime;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;

    void Start ()
    {
        enemyBehavior = GetComponent<RandomEnemyBehavior>();

        GameObject playerPosMessenger = GameObject.FindWithTag("Player");

        if (playerPosMessenger != null)
        {
            playerPos = playerPosMessenger.GetComponent<Transform>();
        }

        waitTime = startWaitTime;
        checkpoint = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        lockDistantBool = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyBehavior.whatBehavior == RandomEnemyBehavior.Behavior.patrol && enemyBehavior.canMove == true)
        {
            IdleMovement();
        }

        else if (enemyBehavior.whatBehavior == RandomEnemyBehavior.Behavior.flee && enemyBehavior.canMove == true)
        {
            // DEBUGGING \\
            
            /*Vector2 fleeDirection = transform.position - playerPos.position; // donne la distance entre le joueur et l'ennemi
            Vector2 playerPosition = playerPos.position; // conversion Vector3 en Vector2
            desiredPosition = playerPosition + (fleeDirection.normalized * desiredDistance);

            Vector2 fleeDirection = transform.position - playerPos.position;
            desiredPosition = fleeDirection.normalized * desiredDistance;

            transform.position = Vector2.MoveTowards(transform.position, desiredPosition, enemySpeed * Time.deltaTime);*/

            //\

            DistantMovement();
        }
    }

    void IdleMovement()
    {
        if (enemyBehavior.isAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, checkpoint, enemySpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, checkpoint) <= 0.2f)
            {
                if (waitTime <= 0)
                {
                    waitTime = startWaitTime;
                    float clsMinX = transform.position.x + minX;
                    float clsMaxX = transform.position.x + maxX;
                    float clsMinY = transform.position.y + minY;
                    float clsMaxY = transform.position.y + maxY;
                    checkpoint = new Vector2(Random.Range(clsMinX, clsMaxX), Random.Range(clsMinY, clsMaxY));
                }

                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    void DistantMovement()
    {
        if (enemyBehavior.isAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, desiredPosition, enemySpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, desiredPosition) <= 0.1f || lockDistantBool == true)
            {
                lockDistantBool = false;

                if (waitDistantTime <= 0)
                {
                    waitDistantTime = startWaitDistantTime;
                    calculateNewPosition();
                }

                else
                {
                    waitDistantTime -= Time.deltaTime;
                }
            }
        }
    }

    void calculateNewPosition()
    {
        if (Vector2.Distance(transform.position, playerPos.position) <= safeSpace)
        {
            // OLD SHIT\\

            //distantCheckpoint = new Vector2(transform.position.x + playerPos.position.x, transform.position.y + playerPos.position.y);

            /*Vector2 fleeDirection = transform.position - playerPos.position;
            Vector2 playerPosition = playerPos.position;
            desiredPosition = playerPosition + (fleeDirection.normalized * desiredDistance);*/

            //\

            Vector2 fleeDirection = transform.position - playerPos.position;
            desiredPosition = fleeDirection.normalized * desiredDistance;
        }
    }
}
