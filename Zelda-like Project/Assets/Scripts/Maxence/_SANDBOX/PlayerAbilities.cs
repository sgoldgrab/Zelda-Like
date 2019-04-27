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

    [SerializeField] private PlayerStance playerStance;
    private bool doubleTap = false;

    private bool[] cooldownIsOver = new bool[6];
    private float[] coolDownTime = new float[6];
    [SerializeField] private float[] startCoolDownTime;

    private string buttonName;
    private bool inputPressed;
    private int index;

    private bool createBluePrint = true;

    private PlayerMovement playerMovement;

    private Vector2 transformPos;
    public Vector2 aimPos { get; private set; }
    private float posX;
    private float posY;
    [SerializeField] private float aimDistance;

    //Bools
    public bool canUseAbility { get; set; } = true;

    //PotionsEffects
    [SerializeField] private List<PotionsEffects> potionsEffects;
    [SerializeField] private int[] potionsValues;
    [SerializeField] private float[] potionsDurations;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        for (int y = 0; y < 6; y++)
        {
            cooldownIsOver[y] = true;
        }

        for (int x = 0; x < 6; x++) //pas utile
        {
            coolDownTime[x] = startCoolDownTime[x];
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
                }
            }

            if (inputPressed)
            {
                Ability(index, true, aimDistance);
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
                }
            }

            if (inputPressed)
            {
                Ability(index, false, aimDistance);
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
                coolDownTime[i] -= Time.deltaTime;
            }
        }
    }

    void Ability(int index, bool stance, float aBDistance)
    {
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
                drinkTimer = drinkTime;

                doubleTap = false;

                canDrink = false;

                //playerMovement.canMove = false; --> probably an animation with a function stopMove() and recover() at the first and last frames

                Debug.Log("ça fait du bien par où ça passe !"); //drinks the potion

                potionsEffects[index].Effect(potionsValues[index], potionsDurations[index]);
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

        playerMovement.canMove = true;

        doubleTap = false;

        if (rStance == false)
        {
            cooldownIsOver[rIndex + 3] = false;
            coolDownTime[rIndex + 3] = startCoolDownTime[rIndex + 3];

            GameObject spell = Instantiate(spells[rIndex], transformPos + aimPos, Quaternion.identity);

            //ONLY SPELL 1
            if (spell.GetComponent<SpellOne>() == null) return;
            else { spell.GetComponent<SpellOne>().SetPositions(aimPos); }
        }

        else if (rStance == true)
        {
            cooldownIsOver[rIndex] = false;
            coolDownTime[rIndex] = startCoolDownTime[rIndex];

            GameObject potion = Instantiate(potions[rIndex], transformPos + aimPos, Quaternion.identity);
        }
    }

    void Blueprint(int bPIndex, bool bPStance, float bPDistance)
    {
        if (releaseTimer > releaseTime)
        {
            playerMovement.canMove = false;
            doubleTap = false;

            if (createBluePrint)
            {
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
            aimPos = (rawAimCoordinates * distance).normalized;
        }
    }
}
