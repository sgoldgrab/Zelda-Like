using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMove : MonoBehaviour {

    private RandomEnemyBehavior enemyBehavior;

    [SerializeField]
    private float fBSpeed;
    [SerializeField]
    private float fBDamage;

    private Vector2 currentPlayerPos;

    public void SetPlayerPos(Vector2 pos)
    {
        currentPlayerPos = pos;
    }

    private float distance;

    private Animator fBAnimator;
    private bool fBIsAnimated = true;

    private bool lockBool = false;

    private PlayerControllerEzEz playerControllerScript;

    void Start()
    {
        fBAnimator = GetComponent<Animator>();

        //enemyBehavior = GetComponentInParent<RandomEnemyBehavior>();
        //currentPlayerPos = enemyBehavior.playerPos;

        GameObject playerControllerMessenger = GameObject.FindWithTag("Player");

        if (playerControllerMessenger != null)
        {
            playerControllerScript = playerControllerMessenger.GetComponent<PlayerControllerEzEz>();
        }
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentPlayerPos, fBSpeed * Time.deltaTime);
        distance = Vector2.Distance(transform.position, currentPlayerPos);

        if (currentPlayerPos.x == transform.position.x && currentPlayerPos.y == transform.position.y && lockBool == false)
        {
            //fBIsAnimated = true;
            ExplosionAnim();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<PlayerCaracteristics>().playerHealth <= 0) // PLAYER IS DEAD
            {
                playerControllerScript.playerIsDead = true;
                //Destroy(other.gameObject);
            }

            else if (other.GetComponent<PlayerCaracteristics>().playerHealth > 0) // PLAYER TAKES DAMAGE
            {
                other.GetComponent<PlayerCaracteristics>().playerHealth -= fBDamage;
                Debug.Log("Damage to the Player !" + other.GetComponent<PlayerCaracteristics>().playerHealth);

                other.GetComponent<HealthPlayer>().TakeDamage();
            }

            //fBIsAnimated = true;
            ExplosionAnim();
        }
    }

    void ExplosionAnim()
    {
        if (fBIsAnimated)
        {
            //lockBool = true;
            fBAnimator.SetTrigger("explosion");
            //fBIsAnimated = false;
            StartCoroutine(WaitingForExplosion());
        }
    }

    IEnumerator WaitingForExplosion()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        Destroy(gameObject);
    }

    /*transform.position = Vector2.MoveTowards(transform.position, currentPlayerPos, fBSpeed* Time.deltaTime);

        if (currentPlayerPos.x == transform.position.x && currentPlayerPos.y == transform.position.y && lockBool == false)
        {
            fBIsAnimated = true;
            ExplosionAnim();
        }*/
}