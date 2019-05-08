using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    //on va collide avec ça : // ça me semble ok

    private List<Obstacle> obstacles = new List<Obstacle>();

    private void OnValidate()
    {
        // spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Obstacle obstacleCollider = collision.GetComponent<Obstacle>();
            obstacleCollider.FadeOut();

            if (obstacles.Count == 0 || obstacleCollider.MySpriteRender.sortingOrder -1 < spriteRenderer.sortingOrder)
            {
                spriteRenderer.sortingOrder = obstacleCollider.MySpriteRender.sortingOrder - 1;
            }

            obstacles.Add(obstacleCollider);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Obstacle obstacleCollider = collision.GetComponent<Obstacle>();
            obstacleCollider.FadeIn();

            obstacles.Remove(obstacleCollider);

            if (obstacles.Count == 0)
            {
                spriteRenderer.sortingOrder = 2000; //  not enough layers !!!
            }
            else
            {
                obstacles.Sort();
                spriteRenderer.sortingOrder = obstacles[0].MySpriteRender.sortingOrder - 1;
            }
        }

    }   
}
