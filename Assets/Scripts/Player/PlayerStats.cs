using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Combat")]
    public float damageMultiplier = 1f;
    public float fireRateMultiplier = 1f;

    [Header("Movement")]
    public float moveSpeedMultiplier = 1f;

    public void UpgradeDamage()
    {
        damageMultiplier *= 1.25f;
        Debug.Log("Damage upgraded: " + damageMultiplier);
    }

    public void UpgradeFireRate()
    {
        fireRateMultiplier *= 1.20f;
        Debug.Log("Fire Rate upgraded: " + fireRateMultiplier);
    }

    public void UpgradeMoveSpeed()
    {
        moveSpeedMultiplier *= 1.15f;
        Debug.Log("Move Speed upgraded: " + moveSpeedMultiplier);
    }
}