using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour {

    private float horizontal;
    private float vertical;

    private float testPlayerSpeed;

	void Start ()
    {
		//\
	}
	
	void Update ()
    {
        movement();
	}

    void movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(horizontal * testPlayerSpeed * Time.deltaTime, vertical * testPlayerSpeed * Time.deltaTime, 0);
    }
}
