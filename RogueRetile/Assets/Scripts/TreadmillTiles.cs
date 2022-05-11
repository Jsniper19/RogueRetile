using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillTiles : MonoBehaviour
{
    public PlayerController_Treadmill PCT;
    public bool isTile;
    public bool isEgg;
    public bool isHatched;

    private void Start()
    {
        GameEvents.current.onPlayerMovesLeft += MoveLeft;
        GameEvents.current.onPlayerMovesRight += MoveRight;
        GameEvents.current.onPlayerMovesUp += MoveUp;
        GameEvents.current.onPlayerMovesDown += MoveDown;

        PCT = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController_Treadmill>();
    }



    void MoveUp()
    {
        transform.position = transform.position - new Vector3(0, PCT.TileY, 0);
    }

    void MoveDown()
    {
        transform.position = transform.position + new Vector3(0, PCT.TileY, 0);
    }

    void MoveLeft()
    {
        transform.position = transform.position + new Vector3(PCT.TileX, 0, 0);
    }

    void MoveRight()
    {
        transform.position = transform.position - new Vector3(PCT.TileX, 0, 0);

    }

    private void Update()
    {
        if (isTile)
        {
            if (transform.position.y < (-3 * PCT.TileY) || transform.position.y > (3 * PCT.TileY) || transform.position.x < (-3 * PCT.TileX) || transform.position.x > (3 * PCT.TileX))
            {
                DIE();
            }
        }
    }

    public void DIE()
    {
        GameEvents.current.onPlayerMovesUp -= MoveUp;
        GameEvents.current.onPlayerMovesDown -= MoveDown;
        GameEvents.current.onPlayerMovesLeft -= MoveLeft;
        GameEvents.current.onPlayerMovesRight -= MoveRight;
        if (isEgg)
        { isHatched = true; }
        Destroy(gameObject);
    }
}
