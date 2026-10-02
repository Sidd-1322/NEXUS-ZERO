using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;

    private void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 target = hit.point;
            target.y = transform.position.y;

            Vector3 direction = target - transform.position;

            if (direction.sqrMagnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}