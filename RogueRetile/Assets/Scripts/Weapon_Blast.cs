using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Blast : MonoBehaviour
{
    public GameObject BlastArea;
    public GameObject Ice;
    public PlayerController PCon;
    public DamageEnemy DE;
    public bool COOL;
    public bool firing;

    public float cooldown;
    public float Size;
    public float startSize;
    public float modSize;
    public float damage;
    public float startDamage;
    public float modDamage;


    // Start is called before the first frame FixedUpdate
    void Start()
    {
        Size = startSize;
        damage = startDamage;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (COOL)
        {
            StartCoroutine(Blast());
        }
    }

    IEnumerator Blast()
    {
        COOL = false;
        BlastArea.SetActive(true);
        firing = true;
        yield return new WaitForSeconds(0.1f);
        BlastArea.SetActive(false);
        yield return new WaitForSeconds(cooldown);
        COOL = true;
    }

    public void Equip()
    {
        Size = startSize + modSize * PCon.upgrades;
        gameObject.transform.localScale = new Vector3(Size, Size, 1);
        damage = startDamage + modDamage * PCon.upgrades;
        DE.damage = damage;
        Ice.GetComponent<DamageEnemy>().damage = damage / 8;
        StopAllCoroutines();
        StartCoroutine(Blast());
    }
}
