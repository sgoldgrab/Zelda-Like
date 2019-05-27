using UnityEngine;
using DFTGames.Localization;

public class MenuManager : MonoBehaviour
{
    #region Public Methods

    private void Start()
    {
        //GameObject.Find("DATA").GetComponent<GetComponent<GlobalData>().isEnglish = true;
    }


    public void SetEnglish()
    {
        Localize.SetCurrentLanguage(SystemLanguage.English);
        //GameObject.Find("DATA").GetComponent < GetComponent<GlobalData>().isEnglish = true;
    }

    public void SetFrench()
    {
        Localize.SetCurrentLanguage(SystemLanguage.French);
        //GameObject.Find("DATA").GetComponent < GetComponent<GlobalData>().isEnglish = false;
    }

   

    #endregion Public Methods
}
