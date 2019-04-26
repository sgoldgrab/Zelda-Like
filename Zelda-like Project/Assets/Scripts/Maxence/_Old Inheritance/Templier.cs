using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Templier : Enemy
{
    //Templar Components
    private Animator tAnimator;
    private SpriteRenderer tSpriteRenderer; //used for testing only, color change depending on stance

    //Player Components
    public Transform playerTransform;
    private Vector2 playerPosition;

    private Collider2D[] playerCollider;
    private PlayerAttacks playerAttackScript;

    [SerializeField] private LayerMask thePlayer;

    //Color change //TESTING\\
    [SerializeField] private Color idleColor;
    [SerializeField] private Color combatColor;

    //Behaviors
    private enum templarBehaviors { chase, attack };
    private templarBehaviors templarBehavior = templarBehaviors.chase;
}
