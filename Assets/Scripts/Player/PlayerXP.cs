using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    [SerializeField] private LevelUpUI levelUpUI;
    [SerializeField] private GameHUD gameHUD;

    [Header("XP")]
    [SerializeField] private float currentXP = 0f;
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private float xpToNextLevel = 20f;

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private float levelUpHeal = 20f;

    private void Start()
    {
        if (gameHUD != null)
        {
            gameHUD.UpdateLevel(currentLevel);
            gameHUD.UpdateXP(currentXP, xpToNextLevel);
        }
    }

    public void AddXP(float amount)
    {
        currentXP += amount;

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }

        if (gameHUD != null)
        {
            gameHUD.UpdateXP(currentXP, xpToNextLevel);
        }
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    private void LevelUp()
    {
        currentXP -= xpToNextLevel;
        currentLevel++;

        if (playerHealth != null)
        {
            playerHealth.Heal(levelUpHeal);
        }

        xpToNextLevel *= 1.25f;

        Debug.Log("LEVEL UP! Current Level: " + currentLevel);

        if (levelUpUI != null)
        {
            levelUpUI.ShowLevelUp();
        }

        if (gameHUD != null)
        {
            gameHUD.UpdateLevel(currentLevel);
            gameHUD.UpdateXP(currentXP, xpToNextLevel);
        }
    }
}