using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public Transform[] checkpoints;
    public float enemySpeed;

    private int randomCheckpoint;
    private float waitTime;
    public float startWaitTime;

    void Start ()
    {
        waitTime = startWaitTime;
        randomCheckpoint = Random.Range(0, checkpoints.Length);
	}

	void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, checkpoints[randomCheckpoint].position, enemySpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, checkpoints[randomCheckpoint].position) <= 0.2f)
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;
                randomCheckpoint = Random.Range(0, checkpoints.Length);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
	}
}
