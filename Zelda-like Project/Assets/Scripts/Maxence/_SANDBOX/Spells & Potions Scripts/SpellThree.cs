using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellThree : MonoBehaviour
{
    private Transform playerTransform;
    private PlayerState playerState;

    private Vector3 blinkDir;

    [SerializeField] private float blinkSpeed = 10f;

    [SerializeField] private float blinkDuration;
    private float duration;

    [SerializeField] private bool brokenSpell;

    public void SetPositions(Vector2 pos)
    {
        blinkDir = pos;
    }

    private void Start()
    {
        GameObject playerMessenger = GameObject.Find("PLAYER");

        if (playerMessenger != null)
        {
            playerTransform = playerMessenger.GetComponent<Transform>();
            playerState = playerMessenger.GetComponent<PlayerState>();
        }

        duration = blinkDuration;
    }

    void Update()
    {
        Blink();

        Teleport();

        //StartCoroutine(Die());
    }

    void Blink()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position + blinkDir, blinkSpeed * Time.deltaTime);

        if (duration <= 0.0f)
        {
            foreach (Collider2D col in playerState.playerColliders) col.enabled = true;

            Destroy(gameObject);
        }

        else
        {
            duration -= Time.deltaTime;
        }
    }

    void Teleport()
    {
        playerTransform.position = transform.position;
    }

    IEnumerator Die()
    {        
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && brokenSpell)
        {
            GameObject enemy = other.transform.parent.parent.gameObject;

            enemy.GetComponent<EnemyState>().TakeDamage(1);
        }

        if (other.CompareTag("Base")) Destroy(gameObject);
    }
}
