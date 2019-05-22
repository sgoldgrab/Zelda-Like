using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFromGroundSkill : CombatSkillUpdate
{
    [SerializeField] private float baseRange;
    private float range;
    [SerializeField] private float offsetRange;

    [SerializeField] private float spikeSpeed;

    private Vector3 direction;

    [SerializeField] private GameObject rockySpikes;

    void Start()
    {
        rate = combatInfos[0].attackRate;
        abRate = combatInfos[0].abilityRate;

        range = baseRange;
    }

    public override void Skill(int ind)
    {
        base.Skill(ind);
    }

    public override void SkillUpdate()
    {
        if (rate <= 0 && !activation) { range = baseRange; }

        base.SkillUpdate();
    }

    public override void DirectEffect()
    {
        GameObject rocks = Instantiate(rockySpikes, transform.position + (direction * range), transform.rotation);
        rocks.GetComponent<Animator>().SetFloat("speed", spikeSpeed);

        range += offsetRange;

        base.DirectEffect();
    }

    public override void AbilityAnimMethod()
    {
        LaneDirection();

        base.AbilityAnimMethod();
    }

    public void LaneDirection()
    {
        Vector3 coordinates = enemyState.playerTransform.position - transform.position;
        //Vector3 signedDir = new Vector2(Mathf.Sign(coordinates.x), Mathf.Sign(coordinates.y));
        direction = coordinates.normalized;
    }
}
