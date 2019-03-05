using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TestFilter : MonoBehaviour
{

    private bool theStance = false;

    public GameObject theCamera;
    private PostProcessVolume theVolume;
    private Vignette theVignette

    private void Start()
    {

        theVolume = theCamera.GetComponent<PostProcessVolume>();

        theVignette = theCamera.GetComponent<Vignette>();
        
    }

    private void Update()
    {

        StartCoroutine(Blink());

    }

    IEnumerator Blink()
    {

        if(theStance)
        {

            theVolume.weight = 0;
            theVignette.intensity = 0;
            yield return new WaitForSeconds(1);

        }

        if(!theStance)
        {

            theVolume.weight = 1;
            theVignette.intensity = 1;
            yield return new WaitForSeconds(1);

        }

    }

}
