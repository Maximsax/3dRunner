using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public CollectibleManager collectibleManager;
    public UIManager uiManager;

    private bool isGameRunning = false;

    private void Start()
    {
        collectibleManager.RegisterPlayer(player);
        collectibleManager.OnCoinCountChanged.AddListener(uiManager.UpdateCoinCount);
        player.OnHitObstacle += OnPlayerHitObstacle;
        uiManager.ShowGameOver(false);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        uiManager.ShowMenu(false);
        uiManager.ShowGameOver(false);
        isGameRunning = true;
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void OnPlayerHitObstacle()
    {
        isGameRunning = false;
        Time.timeScale = 0f;
        uiManager.ShowGameOver(true);
    }
}
