﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StartData
{
    public int startHealth;
    public Vector2 startPosition;
}

public class GlobalData : MonoBehaviour
{
    public static GlobalData globalInstance;

    //Stats
    public int playerHealth;

    public List<string> savedSephiroths;

    public Vector2 checkpointPos;

    //Start
    [SerializeField] private StartData startData;

    private void Awake()
    {
        if (globalInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            globalInstance = this;

            InitialSet();
        }

        else if (globalInstance != this) Destroy(gameObject);
    }

    void InitialSet()
    {
        playerHealth = startData.startHealth;
        savedSephiroths = new List<string>(3);
        checkpointPos = startData.startPosition;
    }
}
