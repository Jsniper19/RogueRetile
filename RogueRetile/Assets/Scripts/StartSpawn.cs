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
                Instantiate(Tile, new Vector3(x*PCT.TileX, y*PCT.TileY), Quaternion.identity);
            }
        }
    }
}
