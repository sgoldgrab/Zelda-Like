using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public GameObject[] spells;
    public GameObject[] potions;

    public GameObject lineOfSight;

    public GameObject Player;

    private bool inputPressed = false;
    public bool bluePrint = false;
    private float timer = 0f;

    private GameObject theBluePrint;

    public GameObject blueprintSpell1;
    public GameObject blueprintSpell2;
    public GameObject blueprintSpell3;

    public GameObject blueprintPotion1;
    public GameObject blueprintPotion2;
    public GameObject blueprintPotion3;


    [SerializeField]
    private bool stanceOne = false;
    //private enum whatStance { stanceOne, stanceTwo }
    //private whatStance currentStance = whatStance.stanceOne;

    [SerializeField]
    private bool isReloading = false;


    private void Start()
    {
      GetComponent<PlayerController>();
    }



    private void Update()
    {

        if (Input.GetKeyDown("joystick button 1") && !stanceOne && !isReloading)   //SPELLS
        {


            //currentStance == whatStance.stanceTwo
            //Instantiate(spell1, transform.position, Quaternion.identity);

            inputPressed = true;

        }

        if (inputPressed)
        {

            //on lance un chrono

            timer += Time.deltaTime;

        }
        if (timer > 0.4f && !bluePrint)
        {

            //si le chrono est en dessous de 0.4 (si le joueur a release avant 0,4 sec) on considère que c'est un simpletap donc rien ne se passe avant le release

            //mais si il est au dessus de 0.4, on considère que c'est un hold donc hop instantiate du bluerpint
            //là il faut immobiliser le joueur, et lui permettre de diriger le bluerpint avec le joystick gauce

            theBluePrint = Instantiate(blueprintSpell1, transform.position, Quaternion.identity);
            bluePrint = true;

        }
        if (Input.GetKeyUp("joystick button 1") && !stanceOne && !isReloading)
        {

            //le joueur relâche donc dans tous les cas ça lance la capacité dans la direction qu'il face

            //on réinitialise les bools et le float pour la prochaine capacité

            inputPressed = false;

            Destroy(theBluePrint);

            timer = 0;

            bluePrint = false;

            Instantiate(spells[0], transform.position, Quaternion.identity);

        }



        if (Input.GetKeyDown("joystick button 3") && !stanceOne && !isReloading)
        {
            inputPressed = true;

        }
        if (inputPressed)
        {
            timer += Time.deltaTime;
        }
        if (timer > 0.4f && !bluePrint)
        {
            //là il faut immobiliser le joueur, et lui permettre de diriger le bluerpint avec le joystick gauce

            theBluePrint = Instantiate(blueprintSpell2, transform.position, Quaternion.identity);
            bluePrint = true;

        }
        if (Input.GetKeyUp("joystick button 3") && !stanceOne && !isReloading)
        {

            //le joueur relâche donc dans tous les cas ça lance la capacité dans la direction qu'il face

            //on réinitialise les bools et le float pour la prochaine capacité

            inputPressed = false;

            Destroy(theBluePrint);

            timer = 0;

            bluePrint = false;

            Instantiate(spells[1], transform.position, Quaternion.identity);

        }



        if (Input.GetKeyDown(KeyCode.JoystickButton2) && !stanceOne && !isReloading)
        {
            inputPressed = true;

        }
        if (inputPressed)
        {
            timer += Time.deltaTime;
        }
        if (timer > 0.4f && !bluePrint)
        {
            //là il faut immobiliser le joueur, et lui permettre de diriger le bluerpint avec le joystick gauce

            theBluePrint = Instantiate(blueprintSpell3, transform.position, Quaternion.identity);
            bluePrint = true;

        }
        if (Input.GetKeyUp(KeyCode.JoystickButton2) && !stanceOne && !isReloading)
        {

            //le joueur relâche donc dans tous les cas ça lance la capacité dans la direction qu'il face

            //on réinitialise les bools et le float pour la prochaine capacité

            inputPressed = false;

            Destroy(theBluePrint);

            timer = 0;

            bluePrint = false;

            //Instantiate(spells[2], transform.position, Quaternion.identity);

        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        if (Input.GetKeyDown("joystick button 1") && stanceOne && !isReloading)   //POTIONS
        {
            inputPressed = true;
        }
        if (inputPressed)
        {
            timer += Time.deltaTime;
        }
        if (timer > 0.4f && !bluePrint)
        {
            //là il faut immobiliser le joueur, et lui permettre de diriger le bluerpint avec le joystick gauce


            theBluePrint = Instantiate(blueprintPotion1, transform.position, Quaternion.identity);
            bluePrint = true;
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button0) && stanceOne && !isReloading)
        {
            if (bluePrint == false)
            {
                //applique effet directement sur les stats du joueur                            //ou sinon on le fait tirer sur lui même pour activer direct l'effet depuis un prefab
                inputPressed = false;
                timer = 0;
            }

            if (bluePrint == true)
            {
                //on réinitialise les bools et le float pour la prochaine capacité

                inputPressed = false;

                Destroy(theBluePrint);

                timer = 0;

                bluePrint = false;

                Instantiate(potions[0], transform.position, Quaternion.identity);
            }

        }


        if (Input.GetKeyDown(KeyCode.Joystick1Button3) && stanceOne && !isReloading)   //POTIONS
        {
            inputPressed = true;
        }
        if (inputPressed)
        {
            timer += Time.deltaTime;
        }
        if (timer > 0.4f && !bluePrint)
        {
            //là il faut immobiliser le joueur, et lui permettre de diriger le bluerpint avec le joystick gauce


            theBluePrint = Instantiate(blueprintPotion2, transform.position, Quaternion.identity);
            bluePrint = true;
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button3) && stanceOne && !isReloading)
        {
            if (bluePrint == false)
            {
                //applique effet directement sur les stats du joueur                            //ou sinon on le fait tirer sur lui même pour activer direct l'effet depuis un prefab
                inputPressed = false;
                timer = 0;
            }

            if (bluePrint == true)
            {
                //on réinitialise les bools et le float pour la prochaine capacité

                inputPressed = false;

                Destroy(theBluePrint);

                timer = 0;

                bluePrint = false;

                Instantiate(potions[1], transform.position, Quaternion.identity);
            }

        }


        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && stanceOne && !isReloading)   //POTIONS
        {
            inputPressed = true;
        }
        if (inputPressed)
        {
            timer += Time.deltaTime;
        }
        if (timer > 0.4f && !bluePrint)
        {
            //là il faut immobiliser le joueur, et lui permettre de diriger le bluerpint avec le joystick gauce


            theBluePrint = Instantiate(blueprintPotion3, transform.position, Quaternion.identity);
            bluePrint = true;
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button2) && stanceOne && !isReloading)
        {
            if (bluePrint == false)
            {
                //applique effet directement sur les stats du joueur                            //ou sinon on le fait tirer sur lui même pour activer direct l'effet depuis un prefab
                inputPressed = false;
                timer = 0;
            }

            if (bluePrint == true)
            {
                //on réinitialise les bools et le float pour la prochaine capacité

                inputPressed = false;

                Destroy(theBluePrint);

                timer = 0;

                bluePrint = false;

                Instantiate(potions[2], transform.position, Quaternion.identity);
            }

        }













        //if (bluePrint == true)
        //{
        //on réinitialise les bools et le float pour la prochaine capacité

        // inputPressed = false;

        //Destroy(theBluePrint);

        //timer = 0;

        //bluePrint = false;

        //Instantiate(potion3, transform.position, Quaternion.identity);
        // }








    }
  
}
