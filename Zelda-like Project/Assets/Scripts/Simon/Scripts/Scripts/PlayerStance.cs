using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerStance : MonoBehaviour
{
    #region Variables
    public enum Stance { stanceOne, stanceTwo };
    public Stance whatStance = Stance.stanceOne;

    [SerializeField] private GameObject mainCamera;

    [SerializeField] private GameObject fog;

    [SerializeField] private GameObject mapStanceOne;
    [SerializeField] private GameObject mapStanceTwo;

    private PostProcessVolume volume;
    private PostProcessLayer layer;

    private Vignette vignette;

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float speedCurve;
    #endregion

    private void Awake()
    {

        volume = mainCamera.GetComponent<PostProcessVolume>();

        layer = mainCamera.GetComponent<PostProcessLayer>();

        var foundEffectSettings = volume.profile.TryGetSettings<Vignette>(out vignette);

    }

    public void SwitchStance()
    {
        #region Stance 1 > Stance 2
        if (whatStance == Stance.stanceOne)
        {

            volume.enabled = true;
            layer.enabled = true;

            fog.SetActive(true);
            mapStanceTwo.SetActive(true);
            mapStanceOne.SetActive(false);

            StartCoroutine(BlinkEffect());

            whatStance = Stance.stanceTwo;

        }
        #endregion

        #region Stance 2 > Stance 1
        else if(whatStance == Stance.stanceTwo)
        {

            StartCoroutine(BlinkEffect());

            volume.enabled = false;
            layer.enabled = false;

            fog.SetActive(false);
            mapStanceOne.SetActive(true);
            mapStanceTwo.SetActive(false);

            whatStance = Stance.stanceOne;

        }
        #endregion

        #region Blink filtre
        IEnumerator BlinkEffect()
        {

            float curveTime = 0f;
            float curveAmount = curve.Evaluate(curveTime);

            while(curveAmount < 0.5f)
            {

                curveTime += Time.deltaTime * speedCurve;

                curveAmount = curve.Evaluate(curveTime);

                vignette.intensity.value = curveAmount;

                yield return null;

            }

            while (curveAmount >= 0.5f)
            {

                curveTime += Time.deltaTime * speedCurve;

                curveAmount = curve.Evaluate(curveTime);

                vignette.intensity.value = curveAmount;

                yield return null;

            }

        }
        #endregion

    }

}
