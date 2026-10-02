using UnityEngine;

public class XPCrystal : MonoBehaviour
{
    [SerializeField] private float xpAmount = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerXP playerXP = other.GetComponent<PlayerXP>();

        if (playerXP != null)
        {
            playerXP.AddXP(xpAmount);
            Destroy(gameObject);
        }
    }
}