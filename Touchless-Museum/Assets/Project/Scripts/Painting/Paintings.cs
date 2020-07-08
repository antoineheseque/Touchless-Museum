using UnityEngine;

/// <summary>
/// Linked with ActualizePaingingText.cs, used to control the painting shown
/// </summary>
public class Paintings : MonoBehaviour
{
    [SerializeField] private ActualizePaintingText actualizer = null;
    [SerializeField] private PaintingScriptableObject[] paintings = null;
    [SerializeField] private Transform paintingAnchor = null;

    private int currentIndex = 0;

    private void Start()
    {
        ShowPainting(currentIndex);
    }

    private void ShowPainting(int index)
    {
        RemovePainting();

        // Add painting and change text details
        actualizer.ChangeText(paintings[index]);

        Instantiate(paintings[index].gameObject, paintingAnchor, false);
        currentIndex = index;
    }

    public void SwitchLeft()
    {
        int index = currentIndex-1;
        if (index < 0) index = paintings.Length-1;
        ShowPainting(index);
    }

    public void SwitchRight()
    {
        ShowPainting((currentIndex+1)%paintings.Length);
    }

    private void RemovePainting()
    {
        if (paintingAnchor.childCount > 0)
        {
            Destroy(paintingAnchor.GetChild(0).gameObject);
        }
    }
}