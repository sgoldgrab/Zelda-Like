using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABilities : MonoBehaviour
{

    private bool inputPressed = false;
    public bool bluePrint = false;
    private float timer = 0f;

    private GameObject theBluePrint;

    public GameObject blueprint;
    public GameObject ability;

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.E))
        {

            //le joueur appuie

            inputPressed = true;

        }

        if(inputPressed)
        {

            //on lance un chrono

            timer += Time.deltaTime;

        }

        if(timer > 0.4f && !bluePrint)
        {

            //si le chrono est en dessous de 0.4 (si le joueur a release avant 0,4 sec) on considère que c'est un simpletap donc rien ne se passe avant le release

            //mais si il est au dessus de 0.4, on considère que c'est un hold donc hop instantiate du bluerpint
            //là il faut immobiliser le joueur, et lui permettre de diriger le bluerpint avec le joystick gauce

            theBluePrint = Instantiate(blueprint, transform.position, Quaternion.identity);
            bluePrint = true;

        }

        if(Input.GetKeyUp(KeyCode.E))
        {

            //le joueur relâche donc dans tous les cas ça lance la capacité dans la direction qu'il face

            //on réinitialise les bools et le float pour la prochaine capacité

            inputPressed = false;

            Destroy(theBluePrint);

            timer = 0;

            bluePrint = false;

            Instantiate(ability, transform.position, Quaternion.identity);

        }

    }
    
}
