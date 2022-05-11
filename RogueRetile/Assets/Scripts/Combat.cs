using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public PlayerController PCon;
    public GameObject AimDirection;
    public GameObject Slash;
    public Vector3 Target;
    public Camera Cam;
    public bool cool;

    public float damage;
    public float modDamage;
    public float startDamage;
    public float slashSize;
    public float modSize;
    public float startSize;
    public float cooldown;
    public float modCool;
    public float startCool;
    public float minCooldown;

    private void Start()
    {
        damage = startDamage;
        slashSize = startSize;
        cooldown = startCool;
    }

    private void Update()
    {
        Target = Cam.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.LookAt(Target, Vector3.forward);
        Vector3 temp = -transform.rotation.eulerAngles;
        temp.x = 0f;
        temp.y = 0f;
        transform.rotation = Quaternion.Euler(temp);

        if (Input.GetMouseButtonDown(0))
        {
            if (cool)
            {
                StartCoroutine(AttackCoroutine());
            }
        }
    }

    IEnumerator AttackCoroutine()
    {
        cool = false;
        SwordAttack();
        yield return new WaitForSeconds(cooldown);
        cool = true;
    }

    void SwordAttack()
    {
        GameObject clone = Instantiate(Slash, transform.position, transform.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(transform.up * PCon.slashSpeed, ForceMode2D.Impulse);
        clone.transform.localScale = new Vector3(1 * slashSize, 0.1f * slashSize, 1);
        clone.GetComponent<DamageEnemy>().damage = damage;
    }

    public void equip()
    {
        if (cooldown < minCooldown)
        { cooldown = startCool - modCool * PCon.upgrades; }
        else
        { cooldown = minCooldown; }
        slashSize = startSize + modSize * PCon.upgrades;
        damage = startDamage + modDamage * PCon.upgrades;
        cool = true;
    }
}
