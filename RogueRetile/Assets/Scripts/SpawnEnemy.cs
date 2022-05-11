using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    void Start()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
