using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public TreadmillTiles TT;
    public PlayerController PCon;
    public Rigidbody2D RB;
    public GameObject Freeze;

    public Color colour;
    public float colourValue;
    public float colourFadeSpeed;

    public float enemySpeed;
    public float acceleration;
    public float maxEnemySpeed;
    public float baseDamage;
    public float damage;
    public float health;
    public float inversePower;
    public float icePower;
    private float boost;

    private void Start()
    {
        PCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        health += PCon.progress / inversePower;
        enemySpeed = maxEnemySpeed;
        colour = gameObject.GetComponent<SpriteRenderer>().color;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, PCon.transform.position, enemySpeed * Time.deltaTime);
        damage = baseDamage + PCon.progress / inversePower;
        if (health <= 0)
        {
        TT.DIE();
        }
        boost += acceleration * Time.deltaTime;
        enemySpeed = maxEnemySpeed + boost;

        if (colourValue > 0)
        {
            colour.r = colourValue;
            gameObject.GetComponent<SpriteRenderer>().material.color = colour;
            colourValue -= Time.deltaTime * colourFadeSpeed;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            health -= collision.gameObject.GetComponent<DamageEnemy>().damage;
            colourValue = 255;
        }
        if (collision.CompareTag("Blast"))
        {
            health -= collision.gameObject.GetComponent<DamageEnemy>().damage;
            colourValue = 255;
            RB.AddForce((PCon.transform.position + transform.position) * PCon.blastForce, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ice"))
        {
            enemySpeed = (maxEnemySpeed + boost) / icePower;
            health -= collision.gameObject.GetComponent<DamageEnemy>().damage * Time.deltaTime;
            Freeze.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            PCon.health -= (damage) * Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ice"))
        {
            enemySpeed = maxEnemySpeed + boost;
            Freeze.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        PCon.health -= (damage) * Time.deltaTime;
        }
    }
}
