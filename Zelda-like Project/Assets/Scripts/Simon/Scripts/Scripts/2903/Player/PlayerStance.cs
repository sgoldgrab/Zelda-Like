using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerStance : MonoBehaviour
{
    #region Variables
    public enum Stance { stanceOne, stanceTwo };
    public Stance whatStance = Stance.stanceOne;

    public bool switchIsPossible = true;

    [SerializeField] private GameObject mainCamera;

    [SerializeField] private GameObject shadow;
    [SerializeField] private GameObject fog;

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
        if (whatStance == Stance.stanceOne && switchIsPossible)
        {

            volume.enabled = true;
            layer.enabled = true;

            shadow.SetActive(false);
            fog.SetActive(true);

            StartCoroutine(BlinkEffect());

            whatStance = Stance.stanceTwo;

        }
        #endregion

        #region Stance 2 > Stance 1
        else if(whatStance == Stance.stanceTwo && switchIsPossible)
        {

            StartCoroutine(BlinkEffect());

            volume.enabled = false;
            layer.enabled = false;

            shadow.SetActive(true);
            fog.SetActive(false);

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
