using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{

    private GameObject player;
    private Stances stance;

    private GameObject gameController;
    private GameController script;

    public Sprite newSprite;
    private Sprite oldSprite;

    private float timerThunder = 0.5f;
    public GameObject bolt;

    private void Start()
    {
        oldSprite = this.GetComponent<SpriteRenderer>().sprite;

        player = GameObject.Find("Player");
        stance = player.GetComponent<Stances>();

        gameController = GameObject.Find("GameController");
        script = gameController.GetComponent<GameController>();
    }

    private void Update()
    {
        if (!stance.stanceOne)
        {
            this.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        
        if(stance.stanceOne)
        {
            this.GetComponent<SpriteRenderer>().sprite = oldSprite;
        }

        if(script.stonePlaced)
        {
            timerThunder -= Time.deltaTime;

            if(timerThunder <= 0)
            {
                Instantiate(bolt, new Vector3(0, 0, 0), Quaternion.identity);
                timerThunder = 0.3f;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Breach")
        {
            script.stonePlaced = true;
        }
    }

}
