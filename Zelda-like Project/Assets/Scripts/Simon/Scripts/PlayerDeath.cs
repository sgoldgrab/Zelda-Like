using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject player;
    public GameObject checkPointSpawn;

    private SpriteRenderer playerSprite;

    private InputManager inputScript;
    private PlayerStance stanceScript;

    private GameObject[] enemies;
    //private GameObject[] attacks; //toutes les attaques auront un tag comumn

    public bool checkPoint = false;
    #endregion

    private void Awake()
    {

        playerSprite = player.GetComponent<SpriteRenderer>();

        inputScript = GetComponent<InputManager>();

        stanceScript = player.GetComponent<PlayerStance>();

    }

    #region Testing
    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.P))
        {

            PlayerOnDeath();

        }

        if(Input.GetKeyDown(KeyCode.R))
        {

            PlayerRespawn();

        }

    }
    #endregion

    private void PlayerOnDeath()
    {
        inputScript.isDead = true;

        stanceScript.whatStance = PlayerStance.Stance.stanceOne;

        playerSprite.enabled = false;

        #region Reset enemies & attacks
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //attacks = GameObject.FindGameObjectsWithTag("Attack");

        #region Destroy enemies
        for(int i=0; i<enemies.Length; i++)
        {

            Destroy(enemies[i]);

        }
        #endregion

        #region Destroy attacks
        /*for(int o=0; o<attacks.Length; o++)
        {

            Destroy(attacks[o]);

        }*/
        #endregion
        #endregion

    }

    private void PlayerRespawn()
    {
        #region Checkpoint
        if(checkPoint)
        {

            player.transform.position = checkPointSpawn.transform.position;
            player.transform.rotation = Quaternion.identity;

            playerSprite.enabled = true;
            inputScript.isDead = false;

        }
        #endregion

        #region No checkpoint
        else if(!checkPoint)
        {

            player.transform.position = new Vector3(0, 0, 0);
            player.transform.rotation = Quaternion.identity;

            playerSprite.enabled = true;
            inputScript.isDead = false;

        }
        #endregion
    }

}
