using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour
{
    [SerializeField] private int aOEDamage;
    private Collider2D col;

    [SerializeField] private int layer;

    void Awake()
    {
        GetComponent<Animator>().SetLayerWeight(layer, 1);

        col = GetComponent<Collider2D>();
        col.enabled = false;

        GetComponent<Animator>().SetFloat("speed", 1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.transform.parent.parent.gameObject;

            player.GetComponent<PlayerState>().TakeDamage(aOEDamage);
        }
    }

    void EnableCol()
    {
        col.enabled = true;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        Destroy(gameObject);
    }
}
