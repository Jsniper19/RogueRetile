using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestCollectionEffects : MonoBehaviour
{
    public PlayerController PCon;
    public GameObject UpgradeDescription;
    public Canvas canvas;
    public string sword = "s";
    public string flail = "f";
    public string blast = "b";
    public string health = "h";

    private void Start()
    {
        PCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        canvas = FindObjectOfType<Canvas>();
    }

    public void Collect(string PickupName)
    {
        float upgrade = PCon.upgrades + 1;
        sword = "Sword Level " + upgrade;
        flail = "Flail Level " + upgrade;
        blast = "Ice storm Level " + upgrade;
        health = "Gained 10 Health";

        GameObject clone = Instantiate(UpgradeDescription, Vector3.zero, Quaternion.identity);
        //clone.GetComponent<Text>().text = PickupName;
        if (PickupName == "sword")
        { clone.GetComponent<Text>().text = sword; }
        if (PickupName == "flail")
        { clone.GetComponent<Text>().text = flail; }
        if (PickupName == "blast")
        { clone.GetComponent<Text>().text = blast; }
        if (PickupName == "health")
        { clone.GetComponent<Text>().text = health; }



        clone.transform.SetParent(canvas.transform, false);

    }
}
