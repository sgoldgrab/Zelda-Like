using UnityEngine;
using DFTGames.Localization;

public class MenuManager : MonoBehaviour
{
    #region Public Methods

    public void SetEnglish()
    {
        Localize.SetCurrentLanguage(SystemLanguage.English);        
    }

    public void SetFrench()
    {
        Localize.SetCurrentLanguage(SystemLanguage.French);
    }

   

    #endregion Public Methods
}
