using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController PCon;
    public Slider Health;
    public float maxHealth;
    public float tileStrength;
    public GameObject Tile;
    public SpriteRenderer SR;

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

        //SR.color.a = 255 / 3 * tileStrength;
    }
}
