using UnityEngine;

public class Statues : MonoBehaviour
{
    [SerializeField] private ActualizeStatuesText actualizer = null;
    [SerializeField] private StatuesScriptableObject[] statues = null;
    [SerializeField] private Transform paintingAnchor = null;
    
    private int currentIndex = 0;

    private void Start()
    {
        ShowPainting(currentIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShowPainting((currentIndex+1)%statues.Length);
        }
    }

    private void ShowPainting(int index)
    {
        RemovePainting();

        // Add painting and change text details
        actualizer.ChangeText(statues[index]);

        GameObject statue = Instantiate(statues[index].gameObject, paintingAnchor, false);
        currentIndex = index;
    }

    public void SwitchLeft()
    {
        int index = currentIndex-1;
        if (index < 0) index = statues.Length-1;
        ShowPainting(index);
    }

    public void SwitchRight()
    {
        ShowPainting((currentIndex+1)%statues.Length);
    }

    private void RemovePainting()
    {
        if (paintingAnchor.childCount > 0)
        {
            Destroy(paintingAnchor.GetChild(0).gameObject);
        }
    }
}