using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Instructions;

    public void BeginGame()
    {
        SceneManager.LoadScene("TreadmillGeneration");
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void ToMenu()
    {
        MainMenu.SetActive(true);
        Instructions.SetActive(false);
    }

    public void ToInstructions()
    {
        MainMenu.SetActive(false);
        Instructions.SetActive(true);
    }
}
