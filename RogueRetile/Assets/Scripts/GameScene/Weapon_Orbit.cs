using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Orbit : MonoBehaviour
{
    public PlayerController PCon;
    public DamageEnemy DE;
    public GameObject Pivot;

    public float orbitSpeed;
    public float Size;
    public float modSize;
    public float startSize;
    public float damage;
    public float modDamage;
    public float startDamage;

    private void Start()
    {
        PCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Size = startSize;
        damage = startDamage;
    }

    private void FixedUpdate()
    {
        Pivot.transform.Rotate(0, 0, orbitSpeed);
    }
    public void Equip()
    {
        Size = startSize + modSize * PCon.upgrades;
        damage = startDamage + modDamage * PCon.upgrades;
        DE.damage = damage;
        Pivot.transform.localScale = new Vector3(Size, Size, 1);
    }
}
