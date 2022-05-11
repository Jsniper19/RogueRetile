using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Rb;
    public Vector3 Target;

    //upgradeable stats
    public float health;
    public float armour;
    public float slashSize;
    public float damage;
    public float cooldown;

    //non upgradeable stats
    public float slashSpeed;
    public float slashTime;
    public float speed;
    public float progress;
    public float progressStep;
    public bool alive = true;

    //weps
    public bool sword;
    public bool bow;
    public bool magic;

    private void Start()
    {
        Target = transform.position;
    }

    void Update()
    {
        if (health <= 0)
        {
            alive = false;
            Rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (alive)
        {
            Target = transform.position;
            if (Input.GetKey(KeyCode.A))
            {
                //gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - Speed, transform.position.y), Time.deltaTime * Speed);
                Target.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + Speed, transform.position.y), Time.deltaTime * Speed);
                Target.x = 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                //gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + Speed), Time.deltaTime * Speed);
                Target.y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - Speed), Time.deltaTime * Speed);
                Target.y = -1;
            }

            transform.position = Vector2.MoveTowards(transform.position, Target, speed * Time.deltaTime);
            //Rb.AddForce((transform.position + Target) * speed, ForceMode2D.Force);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (health >= 0)
            {
                health = health - (damage / armour) * Time.deltaTime;
            }
            else
            {
                health = 0;
            }
        }
    }

    public void WeaponSwap()
    {
        int wep = Random.Range(0, 3);
        if (wep == 0)
        { Weapon1(); sword = true; }
        else { sword = false; }
        if (wep == 1)
        { Weapon2(); bow = true; }
        else { bow = false; }
        if (wep == 2)
        { Weapon3(); magic = true; }
        else { magic = false; }
    }

    void Weapon1()
    {
        //sword
        Debug.Log("Sword");
        slashSize = progress * (3f / 6f);
        damage = progress * (1f / 6f);
        cooldown = progress * (2f / 6f);
    }
    void Weapon2()
    {
        //bow
        Debug.Log("Bow");
        slashSize = progress * (1f / 6f);
        damage = progress * (2f / 6f);
        cooldown = progress * (3f / 6f);
    }
    void Weapon3()
    {
        //magic
        Debug.Log("Magic");
        slashSize = progress * (2f / 6f);
        damage = progress * (3f / 6f);
        cooldown = progress * (1f / 6f);
    }

}
