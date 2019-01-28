using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject bolt;
    public GameObject stone;
    public GameObject badStone;

    private float timerBolt = 4f;

    private float minX = -19f;
    private float minY = -12f;
    private float maxX = 19f;
    private float maxY = 12f;

    public bool stonePlaced = false;

    private void Awake()
    {
        Instantiate(stone, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
        Instantiate(stone, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
        Instantiate(stone, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);

        Instantiate(badStone, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
        Instantiate(badStone, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
        Instantiate(badStone, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
    }

    private void Update()
    {
        if(!stonePlaced)
        {
            timerBolt -= Time.deltaTime;
        }

        if (timerBolt <= 0)
        {
            Instantiate(bolt, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
            timerBolt = 6f;
        }
    }

}
