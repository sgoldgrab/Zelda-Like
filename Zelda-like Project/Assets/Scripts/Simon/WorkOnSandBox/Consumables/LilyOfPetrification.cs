using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyOfPetrification : PickUp
{
    //During 5 seconds, makes the player immune to damage, but prevents him from attacking casting abilities or using consumables
    //works well, just have to add the canUseConsumable/canAttack/canSwitch/isImmune bools and to prevent the movement animation when in stasis

    #region Variables
    private PlayerMovement movementScript;
    private TestSimonPlayerAttack attackScript;
    private Inventory inventoryScript;
    private TestSimonPlayerState healthScript;
    private TestSimonPlayerStances stancesScript;
    #endregion

    public override void Consume()
    {
        base.Consume();
        movementScript = player.GetComponent<PlayerMovement>();
        attackScript = player.GetComponent<TestSimonPlayerAttack>();
        inventoryScript = player.GetComponent<Inventory>();
        healthScript = player.GetComponent<TestSimonPlayerState>();
        stancesScript = player.GetComponent<TestSimonPlayerStances>();
        StartCoroutine(LilyEffect(5f));
    }

    IEnumerator LilyEffect(float time)
    {
        healthScript.isImmune = true;
        movementScript.canMove = false;
        attackScript.canAttack = false;
        stancesScript.canSwitch = false;
        //inventoryScript.canUseConsumable = false;
        yield return new WaitForSeconds(time);
        healthScript.isImmune = false;
        movementScript.canMove = true;
        attackScript.canAttack = true;
        stancesScript.canSwitch = true;
        //inventoryScript.canUseConsumable = true;
        Destroy(gameObject);
    }

}
