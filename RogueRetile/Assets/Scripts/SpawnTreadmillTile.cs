using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreadmillTile : MonoBehaviour
{
    public PlayerController PCon;
    public List<GameObject> Tiles = new List<GameObject>();
    public int selectedNumber;

    [Header("Enemy")]
    public float first;
    [Header("wall")]
    public float second;
    [Header("chest")]
    public float third;
    public float third2;
    public float third3;
    [Header("enemy2")]
    public float fourth;
    [Header("enemy3")]
    public float fifth;

    public float tileX;
    public float tileY;

    public int stage;

    private void Start()
    {
        PCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        GameEvents.current.OnPlayerMovesDown += SpawnBottom;
        GameEvents.current.OnPlayerMovesUp += SpawnTop;
        GameEvents.current.OnPlayerMovesLeft += SpawnRight;
        GameEvents.current.OnPlayerMovesRight += SpawnLeft;
    }

    private void FixedUpdate()
    {
        if (PCon.progress < 100)
        { stage = 1; }
        else if (PCon.progress < 200)
        { stage = 2; }
        else
        { stage = 3; }


        if (stage == 1)
        {
            if (first < 100 - (second + third + fourth + fifth))
            {
                first = PCon.progress;
            }
            else
            {
                first = 100 - (second + third + fourth + fifth);
            }
        }
        else if (stage == 2)
        {
            third = third2;
            if (first < 100 - (second + third + fourth + fifth))
            {
                first = PCon.progress - 90;
            }
            else
            {
                first = 100 - (second + third + fourth + fifth);
            }
            if (fourth < 30)
            {
                fourth = PCon.progress / 15;
            }
            else
            {
                fourth = 30;
            }
        }
        else if (stage == 3)
        {
            third = third3;
            if (first < 100 - (second + third + fourth + fifth))
            {
                first = PCon.progress - 190;
            }
            else
            {
                first = 100 - (second + third + fourth + fifth);
            }
            if (fourth < 30)
            {
                fourth = (PCon.progress - 190) / 10;
            }
            else
            {
                fourth = 30;
            }
            if (fifth < 20)
            {
                fifth = (PCon.progress - 190) / 20;
            }
            else
            {
                fifth = 20;
            }
        }
    }

    void SpawnTop()
    {
        //Debug.Log("Top");

        for (int x = -3; x < 4; x++)
        {
            SelectTile();
            Instantiate(Tiles[selectedNumber], new Vector3(x * tileX, 3 * tileY), Quaternion.identity);
        }
    }
    void SpawnBottom()
    {
        //Debug.Log("Bottom");
        for (int x = -3; x < 4; x++)
        {
            SelectTile();
            Instantiate(Tiles[selectedNumber], new Vector3(x * tileX, -3 * tileY), Quaternion.identity);
        }
    }
    void SpawnLeft()
    {
        //Debug.Log("Left");

        for (int y = -3; y < 4; y++)
        {
            SelectTile();
            Instantiate(Tiles[selectedNumber], new Vector3(3 * tileX, y * tileY), Quaternion.identity);
        }
    }
    void SpawnRight()
    {
        //Debug.Log("Right");
        for (int y = -3; y < 4; y++)
        {
            SelectTile();
            Instantiate(Tiles[selectedNumber], new Vector3(-3 * tileX, y * tileY), Quaternion.identity);
        }
    }

    void SelectTile()
    {
        var RandNum = Random.Range(0, 100);
        if (RandNum < first)
        {
            selectedNumber = 1;
        }
        else if (RandNum > first && RandNum < first + second)
        {
            selectedNumber = 2;
        }
        else if (RandNum > first + second && RandNum < first + second + third)
        {
            selectedNumber = 3;
        }
        else if (RandNum > first + second + third && RandNum < first + second +third + fourth)
        {
            selectedNumber = 4;
        }
        else if (RandNum > first + second + third + fourth && RandNum < first + second + third + fourth + fifth)
        {
            selectedNumber = 5;
        }
        else
        {
            selectedNumber = 0;
        }
    }
}
