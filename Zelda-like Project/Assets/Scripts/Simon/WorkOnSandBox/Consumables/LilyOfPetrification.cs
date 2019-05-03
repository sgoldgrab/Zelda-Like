using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyOfPetrification : PickUp
{
    //During 5 seconds, makes the player immune to damage, but prevents him from attacking casting abilities or using consumables

    #region Variables
    private PlayerMovement movementScript;
    private TestSimonPlayerAttack attackScript;
    private TestSimonInventory inventoryScript;
    private TestSimonPlayerState healthScript;
    #endregion

    public override void Consume()
    {
        base.Consume();
        movementScript = player.GetComponent<PlayerMovement>();
        attackScript = player.GetComponent<TestSimonPlayerAttack>();
        inventoryScript = player.GetComponent<TestSimonInventory>();
        healthScript = player.GetComponent<TestSimonPlayerState>();
        StartCoroutine(LilyEffect(5f));
    }

    IEnumerator LilyEffect(float time)
    {
        healthScript.isImmune = true;
        movementScript.canMove = false;
        attackScript.canAttack = false;
        inventoryScript.canUseConsumable = false;
        yield return new WaitForSeconds(time);
        healthScript.isImmune = false;
        movementScript.canMove = true;
        attackScript.canAttack = true;
        inventoryScript.canUseConsumable = true;
        Destroy(this);
    }

}
