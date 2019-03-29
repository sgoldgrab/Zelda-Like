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

    [SerializeField] private enum Stance { stance1, stance2 };
    [SerializeField] private Stance whatStance = Stance.stance1;

    public float horizontal;
    public float vertical;

    public bool playerWasHit = false;
    public bool playerHasFallen = false;

    private PlayerCaracteristics playerCaracteristics;
    private PlayerAbilitiesBis playerAbilities;

    [HideInInspector] public bool playerIsHitByTheTemplar;
    [HideInInspector] public bool playerIsDead;

    private HealthPlayer healthPlayerScript;

    public float lastX;
    public float lastY;

    public bool canMove = true;

    public bool immuneToDamage = false;
    public int damageAbsorbed = 0;

    [SerializeField] private Camera camStance1;
    [SerializeField] private Camera camStance2;

    [SerializeField] private Canvas userInterface;

    /*public float LastX { get; set; }
    public float LastY { get; set; }*/

    public AnimationCurve curve;

    void Awake()
    {

        PostProcessVolume volume = Camera.main.GetComponent<PostProcessVolume>();

        Vignette v;

        var foundEffectSettings = volume.profile.TryGetSettings<Vignette>(out v);
        v.intensity.value = 1f;
    
        //v.intensity.value = curve.Evaluate(0.5f);

    }

    void Start()
    {
        animator = GetComponent<Animator>();

        playerCaracteristics = GetComponent<PlayerCaracteristics>();

        playerAbilities = GetComponent<PlayerAbilitiesBis>();

        healthPlayerScript = GetComponent<HealthPlayer>();
    }

	// Update is called once per frame
	void Update ()
    {
        Direction();

        StanceSwitch();

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
            if (whatStance == Stance.stance1) //switch to stance 2
            {
                //tilemapS1.color = invisible;
                //tilemapS2.color = visible;

                whatStance = Stance.stance2;

                camStance1.enabled = false;
                camStance2.enabled = true;

                userInterface.worldCamera = camStance1;

                playerAbilities.stanceOne = false;


            }

            else if (whatStance == Stance.stance2) // switch to stance 1
            {
                //tilemapS1.color = visible;
                //tilemapS2.color = invisible;

                whatStance = Stance.stance1;

                camStance1.enabled = true;
                camStance2.enabled = false;

                userInterface.worldCamera = camStance2;

                playerAbilities.stanceOne = true;
            }
        }
    }

    public void DamageToThePlayer(Templar templarScript)
    {
        playerCaracteristics.playerHealth -= templarScript.templarDamage;

        if(playerCaracteristics.playerHealth > 0)
        {

            if (immuneToDamage)
            {

                damageAbsorbed += 1;

            }

            else
            {

                animator.SetTrigger("playerIsHit");

                Debug.Log("Damage to the playeeer FUsckjklj !!!!");
                Debug.Log(playerCaracteristics.playerHealth);
                healthPlayerScript.TakeDamage();

            }

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