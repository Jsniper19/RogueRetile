using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHatching : MonoBehaviour
{
    public TreadmillTiles TT;
    public GameObject Enemy;

    private void Update()
    {
        if (TT.isHatched)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
        }
    }
}
