using UnityEngine;

/// <summary>
/// Painting scriptableObject
/// </summary>
[CreateAssetMenu(fileName = "Painting", menuName = "ScriptableObjects/PaintingScriptableObject")]
public class PaintingScriptableObject : ScriptableObject
{
    public string paintingName = "Unknown";
    public GameObject gameObject;
    public string author = "Antoine";
    public string creationDate = "2020";
    public string description = "";
    public string location = "";
}
