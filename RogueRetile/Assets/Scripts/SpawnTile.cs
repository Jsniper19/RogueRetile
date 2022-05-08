using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public List<GameObject> Tiles = new List<GameObject>();
    public bool Spawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            Spawn = false;
        }
        else
        {
            Spawn = true;
        }


        /*if (Spawn == true)
        {
            if (collision.CompareTag("Player"))
            {
                Instantiate(Tiles[Random.Range(0, Tiles.Count - 1)], transform.position, Quaternion.identity);
                Debug.Log("Spawn");
            }
        }*/
    }

    private void Update()
    {
        if (Spawn)
        {
            Instantiate(Tiles[Random.Range(0, Tiles.Count - 1)], (), Quaternion.identity);
        }
    }
}
