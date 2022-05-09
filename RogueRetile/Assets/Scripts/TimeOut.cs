using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : MonoBehaviour
{
    public float killTime;
    public TreadmillTiles TreadmillTiles;
    void Start()
    {
        StartCoroutine(TimeToDie());
    }

    IEnumerator TimeToDie()
    {
        yield return new WaitForSeconds(killTime);
        TreadmillTiles.DIE();
    }
}
