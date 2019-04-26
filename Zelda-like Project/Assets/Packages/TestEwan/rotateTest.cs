using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTest : MonoBehaviour
{
    //TEST 1

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float radius;

    private Vector2 center;
    private float angle;

    //TEST 2

    [SerializeField] private float distanceAngle;
    [SerializeField] private float distanceRadius;
    private float offsetDistance;

    [SerializeField] private Transform playerPos;

    [SerializeField] private float offsetSpeed;

    private void Start()
    {
        center = transform.position;
    }

    private void Update()
    {
        //RotateTest1();
        RotateTest2();
    }

    void RotateTest1()
    {
        angle += rotateSpeed * Time.deltaTime;

        Vector2 destination = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        //transform.position = destination;

        transform.position = Vector2.MoveTowards(center, destination, rotateSpeed * Time.deltaTime);
    }

    void RotateTest2()
    {
        //offset calculus
        Vector3 offsetValue = new Vector3(Random.Range(-1,1), Random.Range(-1,1), 0.0f);
        Vector3 offset = offsetValue * offsetDistance;
        Vector3 desiredOffset = Vector3.MoveTowards(playerPos.position, offset, offsetSpeed);

        //angle rotation calculus
        Vector3 desiredPosition = Quaternion.AngleAxis(distanceAngle, Vector3.forward) * new Vector3(distanceRadius, 0f);

        //movement
        Vector3 desiredDistance = desiredPosition + desiredOffset;
        transform.position = playerPos.position + desiredDistance;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerPos.position, distanceRadius);
    }
}
