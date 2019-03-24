using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplarSight : MonoBehaviour
{
    private enum TemplarBehaviors { patrol, chase };
    private TemplarBehaviors behavior = TemplarBehaviors.patrol;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            behavior = TemplarBehaviors.chase;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            behavior = TemplarBehaviors.patrol;
        }
    }
}
