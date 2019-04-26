using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyOfPetrificaion : PickUp
{
    //During 5 seconds, makes the player immune to damage, but prevents him from attacking casting abilities or using consumables

    private PlayerMovement movementScript;
    private PlayerAttack attackScript;
    private Inventory inventoryScript;
    private PlayerState healthScript;

    public override void Consume()
    {
        base.Consume();
        movementScript = player.GetComponent<PlayerMovement>();
        attackScript = player.GetComponent<PlayerAttack>();
        inventoryScript = player.GetComponent<Inventory>();
        healthScript = player.GetComponent<PlayerState>();
        StartCoroutine(LilyEffect(5f));
    }

    IEnumerator LilyEffect(float time)
    {
        //healthScript.isImmune = true;
        movementScript.canMove = false;
        //attackScript.canAttack = false;
        //inventoryScript.canUseConsumable = false;
        yield return new WaitForSeconds(time);
        //healthScript.isImmune = false;
        movementScript.canMove = true;
        //attackScript.canAttack = true;
        //inventoryScript.canUseConsumable = true;
        Destroy(this);
    }

}
