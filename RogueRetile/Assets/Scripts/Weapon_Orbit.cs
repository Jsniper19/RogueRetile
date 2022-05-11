using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Orbit : MonoBehaviour
{
    public PlayerController PCon;
    public float orbitSpeed;

    private void Start()
    {
        PCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        transform.Rotate(0, 0, orbitSpeed);
    }
}
