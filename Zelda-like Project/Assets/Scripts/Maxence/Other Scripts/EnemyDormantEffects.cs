using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDormantEffects : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private GameObject player;

    private float speed;

    public GameObject[] enemyHealth;

    private float directionX;
    private float directionY;

    private float damageTaken;

    private EnemyHealthBar enemyHealthBar;

    private PlayerDormantEffects dormantPlayer;

    private Templar templarScript;

    private bool messengerIsNull = true;

    [SerializeField] private float pullForce;

    private void Start()
    {
        dormantPlayer = GetComponent<PlayerDormantEffects>();

        templarScript = GetComponent<Templar>();

        rb2D = GetComponent<Rigidbody2D>();        

        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (messengerIsNull)
        {
            GameObject enemyHealthBarMessenger = GameObject.FindWithTag("EnemyHealthBar");

            if (enemyHealthBarMessenger != null)
            {
                enemyHealthBar = enemyHealthBarMessenger.GetComponent<EnemyHealthBar>();
                messengerIsNull = false;
            }
        }
    }

    public void Spell1Effect()
    {

        StartCoroutine(SpellOne());

    }

    IEnumerator SpellOne()
    {

        for (int u = 0; u < 2; u++)
        {

            enemyHealthBar.Damaged();

            yield return new WaitForSeconds(2f);

        }
    }

    public void Spell2Effect()
    {

        bool spell2Touched = true;

        rb2D.AddForce(new Vector2(directionX, directionY)); //on récupère ici la direction que le spell a pris

        if (spell2Touched && Vector2.Distance(transform.position, player.transform.position) > 2)
        {
            rb2D.AddForce(new Vector2(-directionX, -directionY)); //l'opposé de la force qu'on a mise avant
            spell2Touched = false;
            //annule le current behavior de l'ennemi
        }
    }

    public void Spell1AndPot1()
    {

        enemyHealthBar.Damaged();
        dormantPlayer.enemiesTouchedCount += 1;

    }

    public void Spell1AndPot2()
    {

        StartCoroutine(SpellOnePot2());

    }

    IEnumerator SpellOnePot2()
    {

        for (int u = 0; u < 2; u++)
        {

            enemyHealthBar.Damaged();

            yield return new WaitForSeconds(0);

        }
    }

    public void Spell2AndPot2()
    {

        GameObject comboPrefab;

        comboPrefab = GameObject.Find("P2S2");

        transform.Translate(comboPrefab.transform.position * pullForce);

    }

    public void Spell2AndPot3()
    {

        StartCoroutine(ComboSpell2Pot3());

    }

    IEnumerator ComboSpell2Pot3()
    {

        templarScript.templarSpeed /= 2;
        //Set la bool du script "glow" à true

        yield return new WaitForSeconds(6);

        templarScript.templarSpeed *= 2;
        //Set la bool du script "glow" à false
    }

    public void Spell3AndPot1()
    {

        //???

    }
}
