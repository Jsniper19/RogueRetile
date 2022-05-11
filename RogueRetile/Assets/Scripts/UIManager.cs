using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController PCon;
    public Text Health;
    public Text TileStrength;

    private void Start()
    {
        PCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        Health.text = PCon.health.ToString();
    }
}
