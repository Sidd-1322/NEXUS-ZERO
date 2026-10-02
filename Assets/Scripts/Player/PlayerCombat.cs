using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [Header("Weapon")]
    [SerializeField] private float fireRate = 3f;
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float bulletDamage = 10f;

    private PlayerStats playerStats;

    private float nextFireTime;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            float finalFireRate = fireRate;

            if (playerStats != null)
            {
                finalFireRate *= playerStats.fireRateMultiplier;
            }

            nextFireTime = Time.time + (1f / finalFireRate);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            float finalDamage = bulletDamage;

            if (playerStats != null)
            {
                finalDamage *= playerStats.damageMultiplier;
            }

            bulletScript.SetDamage(finalDamage);
        }

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.linearVelocity = firePoint.forward * bulletSpeed;
        }

        Destroy(bullet, 2f);
    }
}