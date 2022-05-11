using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public TreadmillTiles TT;
    public PlayerController PCon;
    public Rigidbody2D RB;
    public float enemySpeed;
    public float baseDamage;
    public float damage;
    public float health;
    public float blastForce;

    private void Start()
    {
        PCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        health += PCon.progress / 20;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PCon.transform.position, enemySpeed * Time.deltaTime);
        damage = baseDamage + PCon.progress / 20;
        if (health <= 0)
        {
        TT.DIE();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            health -= collision.gameObject.GetComponent<DamageEnemy>().damage;
        }
        if (collision.CompareTag("Blast"))
        {
            Debug.Log("BOOM!");
            health -= collision.gameObject.GetComponent<DamageEnemy>().damage;
            RB.AddForce(transform.position - PCon.transform.position, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        PCon.health -= (damage - 1/20 * PCon.armour) * Time.deltaTime;
        }
    }
}
