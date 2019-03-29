using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplarStatistics : MonoBehaviour
{

    [SerializeField] private HealthScriptableObject healthSCO;
    [SerializeField] private EnemyStatsScriptableObject enemyStatsSCO;
    public Health healthStats;
    public EnemyStats otherStats;


    private void Start()
    {

        healthStats = new Health(healthSCO);
        otherStats = new EnemyStats(enemyStatsSCO);

    }

}
