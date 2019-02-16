using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollisionManager : MonoBehaviour {

    [SerializeField] private Collider2D topCollider, bottomCollider;

    private Transform playerTransform;
    private SpriteRenderer objectSpriteR;

    void Start ()
    {
        objectSpriteR = GetComponent<SpriteRenderer>();

        GameObject playerMessenger = GameObject.FindWithTag("Player");

        if (playerMessenger != null)
        {
            playerTransform = playerMessenger.GetComponent<Transform>();
        }
    }
	
	void Update ()
    {
		if(Vector2.Distance(transform.position, playerTransform.position) < 20.0f)
        {
            //SortingOrder();
            ColliderToUse();
        }
	}

    void SortingOrder()
    {
        objectSpriteR.sortingOrder = (int)Camera.main.WorldToScreenPoint(transform.position).y * -1;
    }

    void ColliderToUse()
    {
        if(playerTransform.position.y > transform.position.y)
        {
            bottomCollider.enabled = true;
            topCollider.enabled = false;
        }

        else
        {
            bottomCollider.enabled = false;
            topCollider.enabled = true;
        }
    }
}
