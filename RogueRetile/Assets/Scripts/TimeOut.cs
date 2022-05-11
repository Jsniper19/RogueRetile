using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : MonoBehaviour
{
    public PlayerController PCon;
    public TreadmillTiles TreadmillTiles;
    void Start()
    {
        PCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        StartCoroutine(TimeToDie());
    }

    IEnumerator TimeToDie()
    {
        yield return new WaitForSeconds(PCon.slashTime);
        TreadmillTiles.DIE();
    }
}
