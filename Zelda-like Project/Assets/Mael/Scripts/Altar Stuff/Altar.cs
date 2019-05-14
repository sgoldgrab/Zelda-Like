using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Altar : MonoBehaviour
{
    public GameObject displaySephs;

    [SerializeField] private List<GameObject> sephirots;

    public Button FirstSeph;
    public EventSystem Yessai;

     [SerializeField]
    private TestArray yesLeArray;


    private void OnTriggerStay2D(Collider2D player)
    {

        if (player.gameObject.tag == "Player") 
        {          
            displaySephs.SetActive(true);
            Yessai.SetSelectedGameObject(FirstSeph.gameObject); 
            //empecher le joueur de bouger
        }
    }

    public void TakeASephi(int theSeph)
    {
        if (theSeph == 1)
        {
            //sephirots[theSeph - 1].GetComponent<Sephiroth>().method();
            yesLeArray.sephirotsSlots[1] = sephirots[theSeph - 1];

        }

        if (theSeph == 2)
        {
            yesLeArray.sephirotsSlots[2] = sephirots[theSeph - 1];
        }

        if (theSeph == 3)
        {           
            yesLeArray.sephirotsSlots[3] = sephirots[theSeph - 1];
        }
    }

    public void DestroyDisplay()
    {
        Destroy(displaySephs);
    }
}
