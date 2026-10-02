using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider xpBar;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text killText;
    [SerializeField] private TMP_Text timerText;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        timerText.text = $"TIME: {minutes:00}:{seconds:00}";
        killText.text = "KILLS: " + Enemy.totalKills;
    }

    public void UpdateLevel(int level)
    {
        levelText.text = "LEVEL " + level;
    }

    public void UpdateXP(float currentXP, float requiredXP)
    {
        xpBar.maxValue = requiredXP;
        xpBar.value = currentXP;
    }
    public float GetSurvivalTime()
    {
        return timer;
    }
}