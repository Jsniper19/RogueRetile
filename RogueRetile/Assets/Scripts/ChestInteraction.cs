using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject Chest;
    public PlayerController PCon;

    private void Start()
    {
        PCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("collide");
            OpenChest();
        }
    }

    void OpenChest()
    {
        AddStat();
        PCon.upgrades += 1;
        Chest.SetActive(false);
        Debug.Log("opened");
    }

    //stat upgrades
    public float healthBuff;
    public float cooldownBuff;
    public float armourBuff;
    public float DamageBuff;
    public float slashSizeBuff;
    private int selectedStat;

    void AddStat()
    {
        selectedStat = Random.Range(0, 6);
        if (selectedStat == 0)
        {
            PCon.health += healthBuff;
            Debug.Log("Health");
        }
        if (selectedStat == 1)
        {
            PCon.armour += armourBuff;
            Debug.Log("Armour");
        }
        if (selectedStat >= 2)
        {
            PCon.WeaponSwap();
            Debug.Log("Swap Weapon");
        }
    }
}
