using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseOne: InteractItem
{
    [SerializeField] private GameObject objet;
    private Altar altar;

    private void Awake()
    {
        altar = objet.GetComponent<Altar>();
    }

    public override void InteractionItem()
    {
        //base.InteractionItem();

        altar.displaySephs.SetActive(true);
        altar.Yessai.SetSelectedGameObject(altar.FirstSeph.gameObject);
        //empecher le joueur de bouger
    }

}
