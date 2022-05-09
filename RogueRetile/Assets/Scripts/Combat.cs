using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject AimDirection;
    public Camera cam;
    public GameObject Slash;
    public float slashSpeed;
    public float Cooldown;
    public bool cool;
    public Vector3 Target;

    private void Update()
    {
        Target = cam.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.LookAt(Target, Vector3.forward);

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
        Attack();
        yield return new WaitForSeconds(Cooldown);
        cool = true;
    }

    void Attack()
    {
        GameObject clone = Instantiate(Slash, transform.position, transform.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(Target.normalized * slashSpeed, ForceMode2D.Impulse);
    }
}
