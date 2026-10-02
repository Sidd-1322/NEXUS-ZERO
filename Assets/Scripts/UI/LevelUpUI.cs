using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;

    private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();

        levelUpPanel.SetActive(false);
    }

    public void ShowLevelUp()
    {
        Debug.Log("SHOWING LEVEL UP PANEL");

        levelUpPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ChooseDamage()
    {
        playerStats.UpgradeDamage();
        ClosePanel();
    }

    public void ChooseFireRate()
    {
        playerStats.UpgradeFireRate();
        ClosePanel();
    }

    public void ChooseMoveSpeed()
    {
        playerStats.UpgradeMoveSpeed();
        ClosePanel();
    }

    private void ClosePanel()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}