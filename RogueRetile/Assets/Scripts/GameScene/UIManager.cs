using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PlayerController PCon;
    public Slider Health;
    public Text score;
    public float maxHealth;
    public float tileStrength;
    public GameObject Tile;
    public Color colour;

    private void Start()
    {
        PCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void FixedUpdate()
    {
        if (PCon.health > maxHealth)
            { maxHealth = PCon.health; }
        Health.value = PCon.health;
        Health.maxValue = maxHealth;
        Health.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxHealth);

        colour.a = (1f / 3f) * (-tileStrength + 3);
        Tile.GetComponent<SpriteRenderer>().material.color = colour;
        float progress = Mathf.RoundToInt(PCon.progress);
        score.text = "Score: " + progress;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("TreadmillGeneration");
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
