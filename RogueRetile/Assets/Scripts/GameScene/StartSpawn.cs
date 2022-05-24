using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawn : MonoBehaviour
{
    public PlayerController_Treadmill PCT;
    public GameObject Tile;

    private void Start()
    {
        for (int x = -3; x < 4; x++)
        {
            for (int y = -3; y < 4; y++)
            {
                if (x != 0 || y != 0)
                    { Instantiate(Tile, new Vector3(x * PCT.tileX, y * PCT.tileY), Quaternion.identity); }
            }
        }
    }
}
