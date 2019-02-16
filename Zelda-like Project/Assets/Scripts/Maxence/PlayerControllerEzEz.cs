using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControllerEzEz : MonoBehaviour {

    private Animator animator;
    public float playerSpeed;

    public Color visible;
    public Color invisible;

    public Tilemap tilemapS1;
    public Tilemap tilemapS2;

    private enum Stance { stance1, stance2 };
    private Stance whatStance = Stance.stance1;

    public float horizontal;
    public float vertical;

    public bool playerWasHit = false;
    public bool playerHasFallen = false;

    private PlayerCaracteristics playerCaracteristics;
    private Templar templarScript;

    [HideInInspector] public bool playerIsHitByTheTemplar;
    [HideInInspector] public bool playerIsDead;

    void Awake()
    {
        GameObject templarMessenger = GameObject.FindWithTag("Templar");

        if (templarMessenger != null)
        {
            templarScript = templarMessenger.GetComponent<Templar>();
            Debug.Log("we found it !"); //\
        }

        if (templarMessenger == null)
        {
            Debug.Log("couldn't find the templar");
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        playerCaracteristics = GetComponent<PlayerCaracteristics>();
    }

	// Update is called once per frame
	void Update ()
    {
        movement();

        StanceSwitch();

        DamageToThePlayer();
	}

    void movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        /*var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");*/

        animator.SetFloat("x", horizontal);
        animator.SetFloat("y", vertical);

        transform.Translate(horizontal * playerSpeed * Time.deltaTime, vertical * playerSpeed * Time.deltaTime, 0);
    }

    void StanceSwitch()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            if (whatStance == Stance.stance1)
            {
                tilemapS1.color = invisible;
                tilemapS2.color = visible;
                whatStance = Stance.stance2;
            }

            else if (whatStance == Stance.stance2)
            {
                tilemapS1.color = visible;
                tilemapS2.color = invisible;
                whatStance = Stance.stance1;
            }
        }
    }

    void DamageToThePlayer()
    {
        if (playerIsHitByTheTemplar)
        {
            playerCaracteristics.playerHealth -= templarScript.templarDamage;
            Debug.Log("Damage to the playeeer FUsckjklj !!!!");
            Debug.Log(playerCaracteristics.playerHealth);
        }

        if (playerIsDead)
        {
            Destroy(gameObject);
        }
    }
}