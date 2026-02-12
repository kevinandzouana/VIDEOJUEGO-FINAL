using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public float deathOffset = 6f;
    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver &&
            player.position.y < Camera.main.transform.position.y - deathOffset)
        {
            isGameOver = true;
            SceneManager.LoadScene("GameOver");
        }
    }
}
