using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public float TimeToDespawn;
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        if (TimeToDespawn > 0)
        {
            TimeToDespawn -= Time.deltaTime;
            transform.position += Vector3.up * Speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
