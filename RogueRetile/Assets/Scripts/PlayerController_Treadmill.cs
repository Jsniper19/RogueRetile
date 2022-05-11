using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Treadmill : MonoBehaviour
{
    public GameObject Player;
    public float tileX;
    public float tileY;

    private void Update()
    {
        if (Player.transform.position.x < -tileX/2)
        {
            GameEvents.current.PlayerMovesLeft();
            Player.transform.position = Player.transform.position + new Vector3 (tileX, 0, 0);
        }

        if (Player.transform.position.y < -tileY/2)
        {
            GameEvents.current.PlayerMovesDown();
            Player.transform.position = Player.transform.position + new Vector3(0, tileY, 0);
        }

        if (Player.transform.position.x > tileX/2)
        {
            GameEvents.current.PlayerMovesRight();
            Player.transform.position = Player.transform.position - new Vector3(tileX, 0, 0);
        }

        if (Player.transform.position.y > tileY/2)
        {
            GameEvents.current.PlayerMovesUp();
            Player.transform.position = Player.transform.position - new Vector3(0, tileY, 0);
        }
    }
}
