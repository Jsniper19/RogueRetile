using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public PlayerController PCon;
    public GameObject AimDirection;
    public GameObject Slash;
    //public GameObject Arrow;
    //public GameObject Blast;
    public Vector3 Target;
    public Camera Cam;
    public bool cool;

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
        if (PCon.sword)
        { SwordAttack(); }
        if (PCon.bow)
        { BowAttack(); }
        if (PCon.magic)
        { MagicAttack(); }
        yield return new WaitForSeconds(1 / PCon.cooldown);
        cool = true;
    }

    void SwordAttack()
    {
        GameObject clone = Instantiate(Slash, transform.position, transform.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(transform.up * PCon.slashSpeed, ForceMode2D.Impulse);
        clone.transform.localScale = new Vector3(1 * PCon.slashSize, 0.1f * PCon.slashSize, 1);
    }

    void BowAttack()
    {
        GameObject clone = Instantiate(Slash, transform.position, transform.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(transform.up * PCon.slashSpeed, ForceMode2D.Impulse);
        clone.transform.localScale = new Vector3(0.1f * PCon.slashSize, 1 * PCon.slashSize, 1);
    }

    void MagicAttack()
    {
        GameObject clone = Instantiate(Slash, transform.position, transform.rotation);
        //clone.GetComponent<Rigidbody2D>().AddForce(transform.up * PCon.slashSpeed, ForceMode2D.Impulse);
        clone.transform.localScale = new Vector3(1.5f * PCon.slashSize, 1.5f * PCon.slashSize, 1);
    }
}
