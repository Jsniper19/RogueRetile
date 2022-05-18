using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillTiles : MonoBehaviour
{
    public PlayerController_Treadmill PCT;
    public UIManager UIM;
    public PlayerController PCon;
    public GameObject Enemy = null;
    public bool isTile;
    public float tileBreakTime;
    public float tileBreakTimeCurrent;
    public bool isEgg;
    public bool isHatched;
    public bool isFirst;

    private void Start()
    {
        GameEvents.current.OnPlayerMovesLeft += MoveLeft;
        GameEvents.current.OnPlayerMovesRight += MoveRight;
        GameEvents.current.OnPlayerMovesUp += MoveUp;
        GameEvents.current.OnPlayerMovesDown += MoveDown;

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

    private void FixedUpdate()
    {
        if (isTile)
        {
            if (transform.position.y < (-3 * PCT.tileY) || transform.position.y > (3 * PCT.tileY) || transform.position.x < (-3 * PCT.tileX) || transform.position.x > (3 * PCT.tileX))
            {
                DIE();
            }
            if (!isFirst)
            {
                if (transform.position == Vector3.zero)
                {
                    tileBreakTimeCurrent -= Time.deltaTime;
                    UIM.tileStrength = tileBreakTimeCurrent;
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
            else
            {
                UIM.tileStrength = tileBreakTimeCurrent;
            }
        }
    }

    public void DIE()
    {
        GameEvents.current.OnPlayerMovesUp -= MoveUp;
        GameEvents.current.OnPlayerMovesDown -= MoveDown;
        GameEvents.current.OnPlayerMovesLeft -= MoveLeft;
        GameEvents.current.OnPlayerMovesRight -= MoveRight;
        if (Enemy != null)
        {
            if (isEgg)
            { Instantiate(Enemy, transform.position, Quaternion.identity); }
        }
        PCon.progress += PCon.progressStep;
        Destroy(gameObject);
    }
}
