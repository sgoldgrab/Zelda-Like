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

    private PlayerState playerState;

    private GlobalData globalData;

    public bool chose = false;

    public bool locked = false;

    void Start()
    {
        playerState = GameObject.Find("PLAYER").GetComponent<PlayerState>();

        globalData = GameObject.Find("DATA").GetComponent<GlobalData>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && altarUI != null && !locked)
        {
            altarUI.SetActive(true);
            eventSystem.SetSelectedGameObject(FirstSeph.gameObject);

            playerState.inMenu = true;
        }
    }

    public void TakeASephi(int theSeph)
    {
        Debug.Log(sephirots[theSeph - 1]);

        ActivateSeph(theSeph);
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
        playerState.inMenu = false;

        Destroy(altarUI);
    }
}
