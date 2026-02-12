using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public float deathOffset = 6f;

    void Update()
    {
        if (player.position.y < Camera.main.transform.position.y - deathOffset)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
