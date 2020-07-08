using UnityEngine;

/// <summary>
/// Rotate the ground on the statue scene
/// </summary>
public class RotatingStand : MonoBehaviour
{
    private const float ROTATION_SPEED = 15f;
    
    private void LateUpdate()
    {
        Transform tr = transform;
        Vector3 euler = tr.eulerAngles;
        euler.y += Time.deltaTime * ROTATION_SPEED;
        tr.eulerAngles = euler;
    }
}
