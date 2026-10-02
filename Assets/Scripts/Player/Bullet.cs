using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;

    public void SetDamage(float amount)
    {
        damage = amount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}