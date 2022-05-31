using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDespawn : MonoBehaviour
{
    public PlayerController_Treadmill PCT;
    public TreadmillTiles TT;

    private void Start()
    {
        PCT = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController_Treadmill>();
    }

    private void Update()
    {
        if (transform.position.y < (-3.5 * PCT.tileY) || transform.position.y > (3.5 * PCT.tileY) || transform.position.x < (-3.5 * PCT.tileX) || transform.position.x > (3.5 * PCT.tileX))
        {
            TT.DIE();
        }
    }
}
