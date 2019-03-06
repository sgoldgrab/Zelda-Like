using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{

    public GameObject healthSegmentPrefab;

    private GameObject healthSegment1;
    private GameObject healthSegment2;
    private GameObject healthSegment3;

    private bool oneDamage = false;
    private bool twoDamage = false;

    private void Start()
    {

        healthSegment1 = Instantiate(healthSegmentPrefab, new Vector2(transform.position.x - 0.4f, transform.position.y), Quaternion.identity);
        healthSegment2 = Instantiate(healthSegmentPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        healthSegment3 = Instantiate(healthSegmentPrefab, new Vector2(transform.position.x +0.4f, transform.position.y), Quaternion.identity);

        healthSegment1.transform.parent = transform;
        healthSegment2.transform.parent = transform;
        healthSegment3.transform.parent = transform;

    }

    public void Damaged()
    {

        if(twoDamage)
        {

            Destroy(healthSegment1.gameObject);

            EnemyDeath();

        }

        else if(oneDamage)
        {

            Destroy(healthSegment2.gameObject);

            twoDamage = true;

        }

        else
        {

            Destroy(healthSegment3.gameObject);

            oneDamage = true;

        }

    }

    private void EnemyDeath()
    {

        Destroy(transform.parent.gameObject);

    }

}
