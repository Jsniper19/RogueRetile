using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreadmillTile : MonoBehaviour
{
    public List<GameObject> Tiles = new List<GameObject>();
    public int selectedNumber;

    public float First = 5;
    public float Second = 10;
    public float Third = 20;

    public float TileX;
    public float TileY;

    private void Start()
    {
        GameEvents.current.onPlayerMovesDown += SpawnBottom;
        GameEvents.current.onPlayerMovesUp += SpawnTop;
        GameEvents.current.onPlayerMovesLeft += SpawnRight;
        GameEvents.current.onPlayerMovesRight += SpawnLeft;
    }

    void SpawnTop()
    {
        Debug.Log("Top");

        for (int x = -3; x < 4; x++)
        {
            SelectTile();
            Instantiate(Tiles[selectedNumber], new Vector3(x * TileX, 3 * TileY), Quaternion.identity);
        }
    }
    void SpawnBottom()
    {
        Debug.Log("Bottom");
        for (int x = -3; x < 4; x++)
        {
            SelectTile();
            Instantiate(Tiles[selectedNumber], new Vector3(x * TileX, -3 * TileY), Quaternion.identity);
        }
    }
    void SpawnLeft()
    {
        Debug.Log("Left");

        for (int y = -3; y < 4; y++)
        {
            SelectTile();
            Instantiate(Tiles[selectedNumber], new Vector3(3 * TileX, y * TileY), Quaternion.identity);
        }
    }
    void SpawnRight()
    {
        Debug.Log("Right");
        for (int y = -3; y < 4; y++)
        {
            SelectTile();
            Instantiate(Tiles[selectedNumber], new Vector3(-3 * TileX, y * TileY), Quaternion.identity);
        }
    }

    void SelectTile()
    {
        var RandNum = Random.Range(0, 100);
        if (RandNum < First)
        {
            selectedNumber = 1;
        }
        else if (RandNum > First && RandNum < First + Second)
        {
            selectedNumber = 2;
        }
        else if (RandNum > First + Second && RandNum < First + Second + Third)
        {
            selectedNumber = 3;
        }
        else
        {
            selectedNumber = 0;
        }
    }
}
