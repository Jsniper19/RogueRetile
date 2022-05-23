using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject Chest;
    public PlayerController PCon;
    public ChestCollectionEffects CCE;

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
        if (selectedStat < 2)
        {
            PCon.health += healthBuff;
            CCE.Collect("health");
            Debug.Log("Health");
        }
        if (selectedStat >= 2)
        {
            WeaponSwap();
            Debug.Log("Swap Weapon");
        }
    }

    public void WeaponSwap()
    {
        int wep = Random.Range(0, 3);
        if (wep == 0)
        {
            PCon.sword.SetActive(true);
            PCon.sword.GetComponent<Combat>().Equip();
            CCE.Collect("sword");
        }
        else { PCon.sword.SetActive(false); }
        if (wep == 1)
        {
            PCon.pivot.SetActive(true);
            PCon.Orbit.GetComponent<Weapon_Orbit>().Equip();
            CCE.Collect("flail");
        }
        else { PCon.pivot.SetActive(false); }
        if (wep == 2)
        {
            PCon.Ice.SetActive(true);
            PCon.Ice.GetComponent<Weapon_Blast>().Equip();
            CCE.Collect("blast");
        }
        else { PCon.Ice.SetActive(false); }
    }
}
