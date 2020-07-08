using UnityEngine;

/// <summary>
/// Statue scriptableObject
/// </summary>
[CreateAssetMenu(fileName = "Painting", menuName = "ScriptableObjects/StatuesScriptableObject")]
public class StatuesScriptableObject : ScriptableObject
{
    public string statueName = "Unknown";
    public GameObject gameObject;
    public string author = "Antoine";
    public string creationDate = "2020";
    public string description = "";
    public string location = "";
}
