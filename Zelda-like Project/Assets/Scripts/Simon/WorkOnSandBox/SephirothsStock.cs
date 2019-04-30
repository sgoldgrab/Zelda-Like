using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SephirothsStock : MonoBehaviour
{

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject malkuth;
    [SerializeField] private GameObject hod;
    [SerializeField] private GameObject yesod;
    [SerializeField] private GameObject nezah;
    [SerializeField] private GameObject gevurah;
    [SerializeField] private GameObject tipheret;
    [SerializeField] private GameObject hesed;
    [SerializeField] private GameObject binah;
    [SerializeField] private GameObject kether;
    [SerializeField] private GameObject hokhmah;

    private PlayerState playerState;
    private PlayerAttack playerAttack;
    private PlayerAbilities playerAbilities;
    private PlayerMovement playerMovement;
    private PlayerSight playerSight;

    [SerializeField] private GameObject[] sephiroths = new GameObject[4];

    private void Awake()
    {
        playerState = player.GetComponent<PlayerState>();
        playerAttack = player.GetComponent<PlayerAttack>();
        playerAbilities = player.GetComponent<PlayerAbilities>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerSight = player.GetComponent<PlayerSight>();
    }

    private void Update()
    {
        while(sephiroths[0] == malkuth) { /* le player peut respawn */ }

        while(sephiroths[1] == hod) { /* +1 HP par attaque réussie */ }

        while(sephiroths[1] == yesod) { /*playerAttack.attackSpeed += 0.5f*/ }

        while (sephiroths[1] == nezah) { /*+30% potion duration*/ }

        while (sephiroths[2] == gevurah) { playerState.maxHealth += 1; }

        while (sephiroths[2] == tipheret) { playerMovement.playerSpeed *= 1.3f; }

        while (sephiroths[2] == hesed) { /* -1 sec de CD par attaque réussie */ }

        while (sephiroths[3] == binah) { playerSight.sightZoneRadius += 1; }

        while (sephiroths[3] == kether) { playerAttack.attackDamage += 1; }

        while (sephiroths[3] == hokhmah) { /*playerAbilities.cooldownReduction += 20;*/ }
    }

}
