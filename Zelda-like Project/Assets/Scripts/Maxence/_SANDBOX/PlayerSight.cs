using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    [SerializeField] private float sightZone;
    public float sightZoneRadius { get => sightZone; set => sightZone = value; }
}
