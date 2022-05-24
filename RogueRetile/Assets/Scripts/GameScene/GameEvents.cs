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

    public event Action OnPlayerMovesLeft;
    public void PlayerMovesLeft()
    {
        if (OnPlayerMovesLeft != null)
        {
            OnPlayerMovesLeft();
        }
    }

    public event Action OnPlayerMovesRight;
    public void PlayerMovesRight()
    {
        if (OnPlayerMovesRight != null)
        {
            OnPlayerMovesRight();
        }
    }

    public event Action OnPlayerMovesUp;
    public void PlayerMovesUp()
    {
        if (OnPlayerMovesUp != null)
        {
            OnPlayerMovesUp();
        }
    }

    public event Action OnPlayerMovesDown;
    public void PlayerMovesDown()
    {
        if (OnPlayerMovesDown != null)
        {
            OnPlayerMovesDown();
        }
    }

}
