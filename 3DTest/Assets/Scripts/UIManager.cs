using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text coinText;
    public GameObject gameOverPanel;
    public GameObject menuPanel;
    private void Start()
    {
        ShowGameOver(false);
        ShowMenu(true);
    }

    public void UpdateCoinCount(int count)
    {
        coinText.text = $"Coins: {count}";
    }

    public void ShowMenu(bool showMenu)
    {
        menuPanel.SetActive(showMenu);
    }

    public void ShowGameOver(bool show)
    {
        gameOverPanel.SetActive(show);
    }
}
