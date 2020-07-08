using UnityEngine;

/// <summary>
/// DontDestroyOnLoad
/// </summary>
public class DontDestroy : MonoBehaviour
{
    private static DontDestroy _instance;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
