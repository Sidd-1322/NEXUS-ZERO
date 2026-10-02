using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameHUD;

    [Header("Stats")]
    [SerializeField] private TMP_Text survivalTimeText;
    [SerializeField] private TMP_Text killsText;
    [SerializeField] private TMP_Text levelText;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (gameHUD != null)
        {
            gameHUD.SetActive(false);
        }

        gameOverPanel.SetActive(true);

        GameHUD hud = FindFirstObjectByType<GameHUD>();
        PlayerXP playerXP = FindFirstObjectByType<PlayerXP>();

        if (hud != null)
        {
            float time = hud.GetSurvivalTime();

            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);

            survivalTimeText.text =
                $"SURVIVAL TIME: {minutes:00}:{seconds:00}";
        }

        killsText.text = "KILLS: " + Enemy.GetTotalKills();

        if (playerXP != null)
        {
            levelText.text =
                "LEVEL REACHED: " + playerXP.GetCurrentLevel();
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}