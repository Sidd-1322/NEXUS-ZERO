using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject xpCrystalPrefab;

    
    [SerializeField] private Slider healthBar;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2f;

    [Header("Health")]
    [SerializeField] private float maxHealth = 30f;


    [Header("Attack")]
    [SerializeField] private float contactDamage = 10f;
    [SerializeField] private float attackCooldown = 1f;

    private float attackTimer;
    private float currentHealth;
    private Transform player;
    public static int totalKills = 0;

    private void Awake()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (player == null)
            return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.01f)
        {
            direction.Normalize();

            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        attackTimer -= Time.deltaTime;

        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= 1.2f && attackTimer <= 0f)
            {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(contactDamage);
                }

                attackTimer = attackCooldown;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0f);

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    public static int GetTotalKills()
    {
        return totalKills;
    }

    private void Die()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            PlayerXP playerXP = playerObject.GetComponent<PlayerXP>();

            if (playerXP != null)
            {
                // Kill reward
                playerXP.AddXP(0.75f);
            }
        }

        totalKills++;

        // Drop XP crystal
        if (xpCrystalPrefab != null)
        {
            Instantiate(
                xpCrystalPrefab,
                transform.position,
                Quaternion.identity
            );
        }
        if (CameraShake.Instance != null)
        {
            CameraShake.Instance.Shake(0.08f, 0.08f);
        }

        Destroy(gameObject);
    }
}