using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New health", menuName = "Health initialization")]
public class HealthScriptableObject : ScriptableObject
{

    public int maxHealth;
    public int currentHealth;

}
