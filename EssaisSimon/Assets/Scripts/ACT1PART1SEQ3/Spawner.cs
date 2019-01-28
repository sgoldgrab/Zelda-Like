using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public GameObject jauge;
    private Slider slider;

    public GameObject enemy;
    public GameObject enemy2;

    [SerializeField]
    private float spawnRate1;
    [SerializeField]
    private float spawnRate2;

    private float timer1;
    private float timer2;

    private void Start()
    {
        timer2 = spawnRate2;
        timer1 = spawnRate1;
        spawnRate1 = 30;
        spawnRate2 = 30;

        slider = jauge.GetComponent<Slider>();

    }

    private void Update()
    {

        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        if (timer1 <= 0 && slider.value < 1)
        {
            
            Spawn1();

        }

        if(timer2 <= 0 && slider.value < 1)
        {

            Spawn2();

        }

    }

    private void Spawn1()
    {

        Instantiate(enemy, transform.position, Quaternion.identity);
        timer1 = spawnRate1;

    }

    private void Spawn2()
    {

        Instantiate(enemy2, transform.position, Quaternion.identity);
        timer2 = spawnRate2;

    }

}
