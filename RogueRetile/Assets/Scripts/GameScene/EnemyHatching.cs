using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHatching : MonoBehaviour
{
    public TreadmillTiles TT;
    public GameObject Enemy;

    public void Hatch()
    {
            Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
