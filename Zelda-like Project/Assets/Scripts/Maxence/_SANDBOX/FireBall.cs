using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private Vector2 currentPlayerPosition;

    private bool allClear = true;

    public void SetPlayerPos(Vector2 pos)
    {
        currentPlayerPosition = pos;
    }

    [SerializeField] private Animator animator;

    void Update()
    {
        if (allClear) transform.position = Vector2.MoveTowards(transform.position, currentPlayerPosition, speed * Time.deltaTime);

        if (currentPlayerPosition.x == transform.position.x && currentPlayerPosition.y == transform.position.y)
        {
            ExplosionAnim();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.transform.parent.parent.gameObject;

            player.GetComponent<PlayerState>().TakeDamage(damage);

            ExplosionAnim();
        }

        if (other.gameObject.tag == "Base") { allClear = false; ExplosionAnim(); }
    }

    void ExplosionAnim()
    {
        animator.SetTrigger("explosion");
        StartCoroutine(WaitingTilAnimIsOver());
    }

    IEnumerator WaitingTilAnimIsOver()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        Destroy(gameObject);
    }
}
