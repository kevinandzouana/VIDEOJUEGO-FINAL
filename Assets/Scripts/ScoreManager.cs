using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Transform player;
    public TMP_Text heightText;
    public TMP_Text coinText;

    private int coins = 0;
    private float maxHeight = 0;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (player.position.y > maxHeight)
            maxHeight = player.position.y;

        heightText.text = "Altura: " + Mathf.FloorToInt(maxHeight);
        coinText.text = "Monedas: " + coins;
    }

    public void AddCoin()
    {
        coins++;
    }
}