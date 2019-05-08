using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{

    public GameObject healthSegmentPrefab;
    public GameObject healthBordureGauchePrefab;
    public GameObject healthBordureDroitePrefab;

    public GameObject healthSegment1;
    public GameObject healthSegment2;
    public GameObject healthSegment3;
    private GameObject healthBordureGauche;
    private GameObject healthBordureDroite;

    private int damageTaken = 0;

    private void Start()
    {

        healthSegment1 = Instantiate(healthSegmentPrefab, new Vector2(transform.position.x -0.4f, transform.position.y), Quaternion.identity);
        healthSegment2 = Instantiate(healthSegmentPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        healthSegment3 = Instantiate(healthSegmentPrefab, new Vector2(transform.position.x +0.4f, transform.position.y), Quaternion.identity);

        healthBordureGauche = Instantiate(healthBordureGauchePrefab, new Vector2(transform.position.x -0.65f, transform.position.y), Quaternion.identity);
        healthBordureDroite = Instantiate(healthBordureDroitePrefab, new Vector2(transform.position.x +0.65f, transform.position.y), Quaternion.identity);

        healthSegment1.transform.parent = transform;
        healthSegment2.transform.parent = transform;
        healthSegment3.transform.parent = transform;
        healthBordureGauche.transform.parent = transform;
        healthBordureDroite.transform.parent = transform;

    }

    public void Damaged()
    {

        if(damageTaken == 2)
        {

            Destroy(healthSegment1.gameObject);

            UIDeath();

        }

        else if(damageTaken == 1)
        {

            Destroy(healthSegment2.gameObject);

            damageTaken += 1;

        }

        else
        {

            Destroy(healthSegment3.gameObject);

            damageTaken += 1;

        }

    }

    public void Healed()
    {
        //re-instantiate health segments
    }

    private void UIDeath()
    {

        Destroy(healthBordureDroite);
        Destroy(healthBordureGauche);

    }

}
