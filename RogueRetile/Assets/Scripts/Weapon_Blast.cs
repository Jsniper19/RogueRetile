using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Blast : MonoBehaviour
{
    public GameObject BlastArea;
    public PlayerController PCon;
    public DamageEnemy DE;
    public float minSize;
    public bool COOL;
    public float growthSpeed;
    public bool firing;

    public float cooldown;
    public float startCool;
    public float modCool;
    public float minCooldown;
    public float maxSize;
    public float startSize;
    public float modSize;
    public float damage;
    public float startDamage;
    public float modDamage;


    // Start is called before the first frame update
    void Start()
    {
        cooldown = startCool;
        maxSize = startSize;
        damage = startDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (COOL && firing == false)
        {
            StartCoroutine(Blast());
        }
        else if (firing == true)
        {
            if (BlastArea.transform.localScale.x < maxSize && BlastArea.transform.localScale.y < maxSize)
            {
                BlastArea.transform.localScale = BlastArea.transform.localScale + new Vector3(growthSpeed, growthSpeed, 0);
            }
            else
            {
                BlastArea.transform.localScale = BlastArea.transform.localScale - new Vector3(BlastArea.transform.localScale.x, BlastArea.transform.localScale.y, 0);
                firing = false;
            }
        }
    }

    IEnumerator Blast()
    {
        COOL = false;
        firing = true;
        yield return new WaitForSeconds(cooldown);
        COOL = true;
    }

    public void equip()
    {
        if (cooldown < minCooldown)
        { cooldown = startCool - modCool * PCon.upgrades; }
        else
        { cooldown = minCooldown; }
        maxSize = startSize + modSize * PCon.upgrades;
        damage = startDamage + modDamage * PCon.upgrades;
        DE.damage = damage;
        COOL = true;
    }
}
