using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacing : MonoBehaviour
{
    public bool rotate;
    public GameObject Enemy;
    public Transform Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (rotate)
        {
            Quaternion rotation = Quaternion.LookRotation (Player.transform.position - transform.position, Vector3.forward);
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
        else
        {
            if (Enemy.transform.position.x > Player.transform.position.x)
            {
                Enemy.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                Enemy.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
