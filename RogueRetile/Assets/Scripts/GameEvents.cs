using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onPlayerMovesLeft;
    public void PlayerMovesLeft()
    {
        if (onPlayerMovesLeft != null)
        {
            onPlayerMovesLeft();
        }
    }

    public event Action onPlayerMovesRight;
    public void PlayerMovesRight()
    {
        if (onPlayerMovesRight != null)
        {
            onPlayerMovesRight();
        }
    }

    public event Action onPlayerMovesUp;
    public void PlayerMovesUp()
    {
        if (onPlayerMovesUp != null)
        {
            onPlayerMovesUp();
        }
    }

    public event Action onPlayerMovesDown;
    public void PlayerMovesDown()
    {
        if (onPlayerMovesDown != null)
        {
            onPlayerMovesDown();
        }
    }

}
