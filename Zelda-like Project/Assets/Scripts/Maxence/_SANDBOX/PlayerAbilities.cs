using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    private float releaseTimer = 0f;
    [SerializeField] private float releaseTime;

    private float drinkTimer;
    [SerializeField] private float drinkTime;

    private bool canDrink = false;

    public GameObject[] spells;
    public GameObject[] potions;

    private GameObject theBluePrint;

    public GameObject[] spellBlueprints;
    public GameObject[] potionBlueprints;

    private bool doubleTap = false;

    private bool[] cooldownIsOver = new bool[6];
    public bool[] notCooldown { get => cooldownIsOver; private set => cooldownIsOver = value; }

    public float[] coolDownTime { get; set; } = new float[6];
    [SerializeField] private float[] startCoolDownTime;
    public float reduction = 1.0f;

    private string buttonName;
    public bool inputPressed { get; private set; }
    private int index;

    private bool createBluePrint = true;

    private PlayerStance playerStance;
    private PlayerAttack playerAttack;
    private PlayerMovement playerMovement;
    private PlayerAnims playerAnims;

    //AimBlueprint
    private Vector2 transformPos;
    public Vector2 aimPos { get; private set; }
    private float posX;
    private float posY;
    [SerializeField] private float[] aimDistances;
    private float angle; // Test rotation

    //Bools
    public bool canUseAbility { get; set; } = true;

    //PotionsDrinkEffects
    [System.Serializable]
    public class PotionsStats
    {
        public int potionValue;
        public float potionDuration;
    }

    [SerializeField] private PotionsEffects potionsEffects;
    [SerializeField] private List<PotionsStats> potionsStats;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerStance = GetComponent<PlayerStance>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAnims = GetComponentInChildren<PlayerAnims>();

        for (int y = 0; y < 6; y++)
        {
            cooldownIsOver[y] = true;
        }

        drinkTimer = drinkTime;
    }

    void Update()
    {
        transformPos = transform.position;

        CoolDown();

        if (canUseAbility) { InputManager(); }
    }

    void InputManager()
    {
        if (playerStance.whatStance == PlayerStance.Stance.stance1)
        {
            if (Input.GetButtonDown("Potion1"))
            {
                if (cooldownIsOver[0])
                {
                    index = 0;
                    inputPressed = true;
                    doubleTap = true;
                    buttonName = "Potion1";
                    //playerAnims.AbilityToUseInAnim(index);
                }
            }

            if (Input.GetButtonDown("Potion2"))
            {
                if (cooldownIsOver[1])
                {
                    index = 1;
                    inputPressed = true;
                    doubleTap = true;
                    buttonName = "Potion2";
                    //playerAnims.AbilityToUseInAnim(index);
                }
            }

            if (Input.GetButtonDown("Potion3"))
            {
                if (cooldownIsOver[2])
                {
                    index = 2;
                    inputPressed = true;
                    doubleTap = true;
                    buttonName = "Potion3";
                    //playerAnims.AbilityToUseInAnim(index);
                }
            }

            if (inputPressed)
            {
                Ability(index, true, aimDistances[0]);
            }
        }

        else if (playerStance.whatStance == PlayerStance.Stance.stance2)
        {
            if (Input.GetButtonDown("Spell1"))
            {
                if (cooldownIsOver[3])
                {
                    index = 0;
                    inputPressed = true;
                    doubleTap = false;
                    buttonName = "Spell1";
                    //playerAnims.AbilityToUseInAnim(index);
                }
            }

            if (Input.GetButtonDown("Spell2"))
            {
                if (cooldownIsOver[4])
                {
                    index = 1;
                    inputPressed = true;
                    doubleTap = false;
                    buttonName = "Spell2";
                    //playerAnims.AbilityToUseInAnim(index);
                }
            }

            if (Input.GetButtonDown("Spell3"))
            {
                if (cooldownIsOver[5])
                {
                    index = 2;
                    inputPressed = true;
                    doubleTap = false;
                    buttonName = "Spell3";
                    //playerAnims.AbilityToUseInAnim(index);
                }
            }

            if (inputPressed)
            {
                Ability(index, false, aimDistances[index + 1]);
            }
        }
    }

    void CoolDown()
    {
        for (int i = 0; i < 6; i++)
        {
            if (coolDownTime[i] <= 0.1f)
            {
                cooldownIsOver[i] = true;
            }

            else
            {
                coolDownTime[i] -= Time.deltaTime * reduction;
            }
        }
    }

    void Ability(int index, bool stance, float aBDistance)
    {
        playerMovement.canMove = false;
        playerStance.canSwitch = false;
        playerAttack.canAttack = false;

        AimDirection(aBDistance);

        if (!canDrink)
        {
            Blueprint(index, stance, aBDistance);
        }

        if (Input.GetButtonUp(buttonName) && !canDrink) //when the player releases the button
        {
            if (!doubleTap) //if the player is in stance 2 (using spells) or if he is already aiming a blueprint
            {
                Release(index, stance); //instantiate the right prefab and return from the function
            }

            else if (doubleTap) //if the player is in stance 1 (using potions) and if he is not aiming a blueprint
            {
                canDrink = true; //allows the second potential input
            }
        }

        HaveADrink(index, stance);
    }

    void HaveADrink(int dIndex, bool dStance)
    {
        if (canDrink)
        {
            if (Input.GetButtonDown(buttonName) && drinkTimer >= 0.0f) //if the player press the button a second time during the right period of time
            {
                inputPressed = false;

                cooldownIsOver[dIndex] = false;
                coolDownTime[dIndex] = startCoolDownTime[dIndex];

                drinkTimer = drinkTime;
                releaseTimer = 0;

                doubleTap = false;

                canDrink = false;

                playerStance.canSwitch = true;
                playerAttack.canAttack = true;

                playerAnims.DrinkAnim();

                Debug.Log("ça fait du bien par où ça passe !"); //drinks the potion

                potionsEffects.Effect(potionsStats[index].potionValue, potionsStats[index].potionDuration, index);
            }

            else if (drinkTimer >= 0.0f) //if the player hasn't pressed the button yet
            {
                drinkTimer -= Time.deltaTime;
            }

            else if (drinkTimer < 0.0f) //if the time period is over
            {
                Release(dIndex, dStance); //releases the potion zone

                canDrink = false;
                drinkTimer = drinkTime;
            }
        }
    }

    void Release(int rIndex, bool rStance)
    {
        inputPressed = false;
        releaseTimer = 0;

        createBluePrint = true;
        Destroy(theBluePrint);

        playerMovement.canMove = true; // --> à remove dès l'intégration de l'anim de release --> use recover method instead
        playerStance.canSwitch = true;
        playerAttack.canAttack = true;

        doubleTap = false;

        //playerAnims.ReleaseAnim();

        if (rStance == false)
        {
            cooldownIsOver[rIndex + 3] = false;
            coolDownTime[rIndex + 3] = startCoolDownTime[rIndex + 3];

            Vector2 instantiatePos = transformPos + aimPos;
            if (rIndex == 2) instantiatePos = transformPos; // only for the spell 3, the instantiation is not on the aim location

            GameObject spell = Instantiate(spells[rIndex], instantiatePos, Quaternion.identity); //Quaternion.Euler(0, 0, angle)

            //CHECK SPELLS
            if (spell.GetComponent<SpellOne>() != null) spell.GetComponent<SpellOne>().SetPositions(aimPos);
            else if (spell.GetComponent<SpellTwo>() != null) spell.GetComponent<SpellTwo>().SetPositions(aimPos);
            else if (spell.GetComponent<SpellThree>() != null) spell.GetComponent<SpellThree>().SetPositions(aimPos);
        }

        else if (rStance == true)
        {
            cooldownIsOver[rIndex] = false;
            coolDownTime[rIndex] = startCoolDownTime[rIndex];

            GameObject potion = Instantiate(potions[rIndex], transformPos + aimPos, Quaternion.identity); //Quaternion.Euler(0, 0, angle)
        }
    }

    void Blueprint(int bPIndex, bool bPStance, float bPDistance)
    {
        if (releaseTimer > releaseTime)
        {
            doubleTap = false;

            if (createBluePrint)
            {
                //playerAnims.HoldAnim();

                if (bPStance == false)
                {
                    theBluePrint = Instantiate(spellBlueprints[bPIndex], transform.position, Quaternion.identity, transform);
                    createBluePrint = false;
                }

                else if (bPStance == true)
                {
                    theBluePrint = Instantiate(potionBlueprints[bPIndex], transform.position, Quaternion.identity, transform);
                    createBluePrint = false;
                }
            }

            else
            {
                theBluePrint.transform.position = transformPos + aimPos;

                // Test Hilda Von Schaft
                theBluePrint.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }

        else if (releaseTimer <= releaseTime)
        {
            releaseTimer += Time.deltaTime;
        }
    }

    void AimDirection(float distance)
    {
        if (playerMovement.lastX != 0 || playerMovement.lastY != 0)
        {
            posX = playerMovement.lastX;
            posY = playerMovement.lastY;

            Vector2 rawAimCoordinates = new Vector2(posX, posY);
            aimPos = rawAimCoordinates.normalized * distance;

            // Test Himmler Von Schaft
            angle = (Mathf.Atan2(posX, posY) * -Mathf.Rad2Deg) + 45;
        }
    }
}
