using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaugeZone : MonoBehaviour
{

    private Slider slider;

    public GameObject zone;
    private Zone scriptZone;

    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;


    private void Start()
    {

        slider = GetComponent<Slider>();
        slider.value = 0;

        scriptZone = zone.GetComponent<Zone>();

    }

    private void Update()
    {

        if(!scriptZone.isOccupied)
        {

            slider.value -= Time.deltaTime * 0.25f;

        }

        else if(scriptZone.isOccupied)
        {

            slider.value += Time.deltaTime * 0.1f;

        }

        if(slider.value == 1)
        {

            Destroy(spawner1.gameObject);   
            Destroy(spawner2.gameObject);
            Destroy(spawner3.gameObject);
            Destroy(zone.gameObject);
            Destroy(this.gameObject);

        }

    }

}
