using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Treadmill : MonoBehaviour
{
    public float TileX;
    public float TileY;
    public GameObject Player;

    private void Update()
    {
        if (Player.transform.position.x < -TileX/2)
        {
            GameEvents.current.PlayerMovesLeft();
            Player.transform.position = Player.transform.position + new Vector3 (TileX, 0, 0);
        }

        if (Player.transform.position.y < -TileY/2)
        {
            GameEvents.current.PlayerMovesDown();
            Player.transform.position = Player.transform.position + new Vector3(0, TileY, 0);
        }

        if (Player.transform.position.x > TileX/2)
        {
            GameEvents.current.PlayerMovesRight();
            Player.transform.position = Player.transform.position - new Vector3(TileX, 0, 0);
        }

        if (Player.transform.position.y > TileY/2)
        {
            GameEvents.current.PlayerMovesUp();
            Player.transform.position = Player.transform.position - new Vector3(0, TileY, 0);
        }
    }
}
