using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillTiles : MonoBehaviour
{
    public PlayerController_Treadmill PCT;
    public UIManager UIM;
    public PlayerController PCon;
    public bool isTile;
    public float tileBreakTime;
    public float tileBreakTimeCurrent;

    private void Start()
    {
        GameEvents.current.onPlayerMovesLeft += MoveLeft;
        GameEvents.current.onPlayerMovesRight += MoveRight;
        GameEvents.current.onPlayerMovesUp += MoveUp;
        GameEvents.current.onPlayerMovesDown += MoveDown;

        PCT = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController_Treadmill>();
        PCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        UIM = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIManager>();
        tileBreakTimeCurrent = tileBreakTime;
    }



    void MoveUp()
    {
        transform.position = transform.position - new Vector3(0, PCT.tileY, 0);
    }

    void MoveDown()
    {
        transform.position = transform.position + new Vector3(0, PCT.tileY, 0);
    }

    void MoveLeft()
    {
        transform.position = transform.position + new Vector3(PCT.tileX, 0, 0);
    }

    void MoveRight()
    {
        transform.position = transform.position - new Vector3(PCT.tileX, 0, 0);

    }

    private void Update()
    {
        if (isTile)
        {
            if (transform.position.y < (-3 * PCT.tileY) || transform.position.y > (3 * PCT.tileY) || transform.position.x < (-3 * PCT.tileX) || transform.position.x > (3 * PCT.tileX))
            {
                DIE();
            }
            if (transform.position == Vector3.zero)
            {
                tileBreakTimeCurrent -= Time.deltaTime;
                UIM.TileStrength.text = "time to break " + tileBreakTimeCurrent.ToString();
                if (tileBreakTimeCurrent <= 0)
                {
                    PCon.alive = false;
                    DIE();
                }
            }
            else
            {
                tileBreakTimeCurrent = tileBreakTime;
            }
        }
    }

    public void DIE()
    {
        GameEvents.current.onPlayerMovesUp -= MoveUp;
        GameEvents.current.onPlayerMovesDown -= MoveDown;
        GameEvents.current.onPlayerMovesLeft -= MoveLeft;
        GameEvents.current.onPlayerMovesRight -= MoveRight;
        PCon.progress += PCon.progressStep;
        Destroy(gameObject);
    }
}
