using UnityEngine;

public class RotatingStand : MonoBehaviour
{
    private const float ROTATION_SPEED = 15f;
    
    private void LateUpdate()
    {
        Vector3 euler = transform.eulerAngles;
        euler.y += Time.deltaTime * ROTATION_SPEED;
        transform.eulerAngles = euler;
    }
}
