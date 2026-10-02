using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    private PlayerStats playerStats;

    private Rigidbody rb;
    private Vector3 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(horizontal, 0f, vertical).normalized;
    }

    private void FixedUpdate()
    {
        float finalMoveSpeed = moveSpeed;

        if (playerStats != null)
        {
            finalMoveSpeed *= playerStats.moveSpeedMultiplier;
        }

        Vector3 newPosition = rb.position + movement * finalMoveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}