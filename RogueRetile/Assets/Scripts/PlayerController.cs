using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Rb;
    public Vector3 Target;
    //public Vector3 AimTarget;

    //upgradeable stats
    public float health;
    public float armour;

    //non upgradeable stats
    public float slashSpeed;
    public float slashTime;
    public float speed;
    public float progress;
    public float progressStep;
    public bool alive = true;
    public int upgrades;

    //weps
    public GameObject sword;
    public GameObject pivot;
    public GameObject Orbit;
    public GameObject Ice;
    public GameObject Blast;
    public GameObject DeathScreen;
    public Text Score;
    public GameObject UI;
    public int wep;

    private void Start()
    {
        Target = transform.position;
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            alive = false;
            Rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Death();
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
            //AimTarget = Target;
            //Rb.AddForce((transform.position + Target) * speed, ForceMode2D.Force);
        }
    }

    public void WeaponSwap()
    {
        if (wep == 0)
        {
            sword.SetActive(true);
            sword.GetComponent<Combat>().Equip();
        }
        else { sword.SetActive(false); }
        if (wep == 1)
        {
            pivot.SetActive(true);
            Orbit.GetComponent<Weapon_Orbit>().Equip();
        }
        else { pivot.SetActive(false); }
        if (wep == 2)
        {
            Ice.SetActive(true);
            Ice.GetComponent<Weapon_Blast>().Equip();
        }
        else { Ice.SetActive(false); }
    }

    void Death()
    {
        float finalScore = Mathf.Round(progress);
        sword.SetActive (false);
        pivot.SetActive (false);
        Ice.SetActive (false);
        UI.SetActive (false);
        DeathScreen.SetActive(true);
        Score.text = "Score " + finalScore;
    }
}
