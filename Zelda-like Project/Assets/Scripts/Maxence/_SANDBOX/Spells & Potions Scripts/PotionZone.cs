using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionZone : MonoBehaviour
{
    [SerializeField] private float timer;

    public GameObject combo1;
    public GameObject combo2;

    [SerializeField] private string compareTag1;
    [SerializeField] private string compareTag2;

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(compareTag1))
        {
            Instantiate(combo1, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if (other.CompareTag(compareTag2))
        {
            Instantiate(combo2, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
