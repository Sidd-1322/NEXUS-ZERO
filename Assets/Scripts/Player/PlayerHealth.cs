using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthBar;

    [Header("Game Over")]
    [SerializeField] private GameOverUI gameOverUI;

    private float currentHealth;
    private bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0f);
        if (CameraShake.Instance != null)
        {
            CameraShake.Instance.Shake(0.18f, 0.18f);
        }

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (isDead)
            return;

        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        Debug.Log("Player healed: " + currentHealth);
    }

    private void Die()
    {
        isDead = true;

        Debug.Log("PLAYER DIED");

        gameObject.SetActive(false);

        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }
    }
}