using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AltarTestSandbox : MonoBehaviour
{
    public GameObject altarUI;

    [SerializeField] private List<GameObject> sephirots;

    public Button FirstSeph;
    public EventSystem eventSystem;

    public Sprite chosenSephSprite;

    private PlayerMovement playerMovement;
    private PlayerDash playerDash;

    private GlobalData globalData;

    public bool chose = false;

    void Start()
    {
        playerMovement = GameObject.Find("PLAYER").GetComponent<PlayerMovement>();
        playerDash = GameObject.Find("PLAYER").GetComponent<PlayerDash>();

        globalData = GameObject.Find("DATA").GetComponent<GlobalData>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && altarUI != null)
        {
            altarUI.SetActive(true);
            eventSystem.SetSelectedGameObject(FirstSeph.gameObject);
            playerMovement.canMove = false;
            //playerDash.canDash = false;
        }
    }

    public void TakeASephi(int theSeph)
    {
        Debug.Log(sephirots[theSeph - 1]);

        if (theSeph == 1)
        {
            ActivateSeph(theSeph);
        }

        if (theSeph == 2)
        {
            ActivateSeph(theSeph);
        }

        if (theSeph == 3)
        {
            ActivateSeph(theSeph);
        }
    }

    public void ActivateSeph(int seph)
    {
        sephirots[seph - 1].GetComponent<Sephiroth>().isActive = true;

        globalData.savedSephiroths.Add(sephirots[seph - 1].name);
        /*
        chosenSephSprite = sephirots[seph - 1].GetComponent<Sephiroth>().sephSprite;
        chose = true;
        */
    }

    public void DestroyUI()
    {
        //StartCoroutine("WaitForDash");
        Destroy(altarUI);
    }

    IEnumerator WaitForDash()
    {
        yield return new WaitForSeconds(0.1f);

        playerDash.canDash = true;
    }
}
