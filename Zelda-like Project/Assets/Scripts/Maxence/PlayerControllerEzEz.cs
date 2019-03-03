using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering.PostProcessing;


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

    [HideInInspector] public bool playerIsHitByTheTemplar;
    [HideInInspector] public bool playerIsDead;

    private HealthPlayer healthPlayerScript;

    public float lastX;
    public float lastY;

    public bool canMove = true;

    /*public float LastX { get; set; }
    public float LastY { get; set; }*/

    void Awake()
    {
        //
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        playerCaracteristics = GetComponent<PlayerCaracteristics>();

        healthPlayerScript = GetComponent<HealthPlayer>();
    }

	// Update is called once per frame
	void Update ()
    {
        Direction();

        //StanceSwitch();

        LastSprite();
	}

    void Direction()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        if (canMove)
        {
            Movement();
        }

        if (horizontal != 0 || vertical != 0)
        {
            lastX = horizontal;
            lastY = vertical;
        }        
    }

    void Movement()
    {
        animator.SetFloat("x", horizontal);
        animator.SetFloat("y", vertical);

        transform.Translate(horizontal * playerSpeed * Time.deltaTime, vertical * playerSpeed * Time.deltaTime, 0);
    }

    void LastSprite()
    {
        if(lastX > 0 && lastY < 0) // bas droite
        {
            animator.SetFloat("lastX", 1);
            animator.SetFloat("lastY", -1);
        }

        if (lastX > 0 && lastY > 0) // haut droite
        {
            animator.SetFloat("lastX", 1);
            animator.SetFloat("lastY", 1);
        }

        if (lastX < 0 && lastY > 0) // haut gauche
        {
            animator.SetFloat("lastX", -1);
            animator.SetFloat("lastY", 1);
        }

        if (lastX < 0 && lastY < 0) // bas gauche
        {
            animator.SetFloat("lastX", -1);
            animator.SetFloat("lastY", -1);
        }
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

    public void DamageToThePlayer(Templar templarScript)
    {
        playerCaracteristics.playerHealth -= templarScript.templarDamage;

        if(playerCaracteristics.playerHealth > 0)
        {
            animator.SetTrigger("playerIsHit");

            Debug.Log("Damage to the playeeer FUsckjklj !!!!");
            Debug.Log(playerCaracteristics.playerHealth);
            healthPlayerScript.TakeDamage();
        }

        else if (playerCaracteristics.playerHealth <= 0)
        {
            animator.SetTrigger("playerIsDead");
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}