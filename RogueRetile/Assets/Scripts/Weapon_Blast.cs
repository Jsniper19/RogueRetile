using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Blast : MonoBehaviour
{
    public GameObject BlastArea;
    public float minSize;
    public float maxSize;
    public float cooldown;
    public bool COOL;
    public float growthSpeed;
    public bool firing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (COOL && firing == false)
        {
            StartCoroutine(Blast());
        }
        else if (firing == true)
        {
            if (BlastArea.transform.localScale.x < maxSize && BlastArea.transform.localScale.y < maxSize)
            {
                BlastArea.transform.localScale = BlastArea.transform.localScale + new Vector3(growthSpeed, growthSpeed, 0);
            }
            else
            {
                BlastArea.transform.localScale = BlastArea.transform.localScale - new Vector3(BlastArea.transform.localScale.x, BlastArea.transform.localScale.y, 0);
                firing = false;
            }
        }
    }

    IEnumerator Blast()
    {
        COOL = false;
        firing = true;
        yield return new WaitForSeconds(cooldown);
        COOL = true;
    }
}
