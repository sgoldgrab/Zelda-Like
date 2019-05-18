using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class Sephiroth : MonoBehaviour
{
    public bool isActive { get; set; } = false;

    public Sprite sephSprite;
}

public class Altar : MonoBehaviour
{
    public GameObject displaySephs;

    [SerializeField] private List<GameObject> sephirots;

    public Button FirstSeph;
    public EventSystem Yessai;

    public Sprite zeSprite;

    [SerializeField] private SephirothsStock sephirothsStock;

    private PlayerMovement playerMovement;

    public bool hasBeenFinallyActivatedAfterAllTheseYears = false;

    void Start()
    {
        playerMovement = GameObject.Find("PLAYER").GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {          
            displaySephs.SetActive(true);
            Yessai.SetSelectedGameObject(FirstSeph.gameObject);
            playerMovement.canMove = false;
        }
    }


    public void TakeASephi(int theSeph)
    {
        Debug.Log(sephirots[theSeph - 1]);

        if (theSeph == 1)
        {
            //sephirots[theSeph - 1].GetComponent<Sephiroth>().method();
            //sephirothsStock.sephirothsInInventory[1] = sephirots[theSeph - 1];
            Debug.Log("Simon aide moi");

            sephirots[theSeph - 1].GetComponent<Sephiroth>().isActive = true;
            zeSprite = sephirots[theSeph - 1].GetComponent<Sephiroth>().sephSprite;
            hasBeenFinallyActivatedAfterAllTheseYears = true;

            Debug.Log("Allez les bleues");

        }

        if (theSeph == 2)
        {
            //sephirothsStock.sephirothsInInventory[2] = sephirots[theSeph - 1];

            sephirots[theSeph - 1].GetComponent<Sephiroth>().isActive = true;
        }

        if (theSeph == 3)
        {           
            //sephirothsStock.sephirothsInInventory[3] = sephirots[theSeph - 1];

            sephirots[theSeph - 1].GetComponent<Sephiroth>().isActive = true;
        }
    }

    public void DestroyDisplay()
    {
        Debug.Log("ENculé");
        Destroy(displaySephs);
    }
}
