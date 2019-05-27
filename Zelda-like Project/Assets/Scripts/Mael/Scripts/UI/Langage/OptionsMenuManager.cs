using UnityEngine;
using DFTGames.Localization;
using TMPro;

public class OptionsMenuManager : MonoBehaviour
{
    private GlobalData globalData;

    [SerializeField] private GameObject difficultyButton;

    void Start()
    {
        globalData = GameObject.Find("DATA").GetComponent<GlobalData>();

        if (globalData.easyMode) difficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Easy";
    }

    #region Public Methods

    public void SetEnglish()
    {
        globalData.isEnglish = true;

        Localize.SetCurrentLanguage(SystemLanguage.English);
    }

    public void SetFrench()
    {
        globalData.isEnglish = false;

        Localize.SetCurrentLanguage(SystemLanguage.French);
    }

    public void SetDifficulty()
    {
        if (!globalData.easyMode)
        {
            globalData.easyMode = true; // set difficulty to low

            difficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Easy";
        }

        else
        {
            globalData.easyMode = false; // set difficulty to high

            difficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Hard";
        }
    }

    #endregion Public Methods
}
