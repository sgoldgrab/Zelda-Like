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

    private Respawn respawn;

    public bool chose = false;

    void Start()
    {
        playerMovement = GameObject.Find("PLAYER").GetComponent<PlayerMovement>();
        playerDash = GameObject.Find("PLAYER").GetComponent<PlayerDash>();

        respawn = GameObject.Find("Respawn").GetComponent<Respawn>();
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
            DisplaySprite(theSeph);

            respawn.savedSephs[theSeph] = sephirots[theSeph - 1];
        }

        if (theSeph == 2)
        {
            DisplaySprite(theSeph);

            respawn.savedSephs[theSeph] = sephirots[theSeph - 1];
        }

        if (theSeph == 3)
        {
            DisplaySprite(theSeph);

            respawn.savedSephs[theSeph] = sephirots[theSeph - 1];
        }
    }

    public void DisplaySprite(int seph)
    {
        sephirots[seph - 1].GetComponent<Sephiroth>().isActive = true;
        chosenSephSprite = sephirots[seph - 1].GetComponent<Sephiroth>().sephSprite;
        chose = true;
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
