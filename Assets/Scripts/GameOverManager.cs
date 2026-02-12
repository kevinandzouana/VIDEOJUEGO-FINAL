using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        // Asegurarse de que el panel esté oculto al iniciar
        gameOverPanel.SetActive(false);
    }

    // Llamar a esta función cuando el jugador muere
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
    }

    // Botón Reiniciar
    public void RestartGame()
    {
        Time.timeScale = 1f; // Reactiva el tiempo
        SceneManager.LoadScene("SampleScene");
    }

    // Botón Ir al Menú
    public void GoToMenu()
    {
        Time.timeScale = 1f; // Reactiva el tiempo
        SceneManager.LoadScene("Menu");
    }
}
