using UnityEngine;

/// <summary>
/// Linked with ActualizeStatuesText.cs, used to control the statue shown
/// </summary>
public class Statues : MonoBehaviour
{
    [SerializeField] private ActualizeStatuesText actualizer = null;
    [SerializeField] private StatuesScriptableObject[] statues = null;
    [SerializeField] private Transform paintingAnchor = null;
    
    private int currentIndex = 0;

    private void Start()
    {
        ShowStatue(currentIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShowStatue((currentIndex+1)%statues.Length);
        }
    }

    private void ShowStatue(int index)
    {
        RemovePainting();

        // Add painting and change text details
        actualizer.ChangeText(statues[index]);

        Instantiate(statues[index].gameObject, paintingAnchor, false);
        currentIndex = index;
    }

    public void SwitchLeft()
    {
        int index = currentIndex-1;
        if (index < 0) index = statues.Length-1;
        ShowStatue(index);
    }

    public void SwitchRight()
    {
        ShowStatue((currentIndex+1)%statues.Length);
    }

    private void RemovePainting()
    {
        if (paintingAnchor.childCount > 0)
        {
            Destroy(paintingAnchor.GetChild(0).gameObject);
        }
    }
}