using UnityEngine;

/// <summary>
/// When a click is detected on a button, switch to Loading state and move camera to the loading position.
/// </summary>
public class SwitchSceneButton : MonoBehaviour
{
    [SerializeField] private string levelName = "Main";
    [SerializeField] private Animator anim = null;
    
    private static readonly int Loading = Animator.StringToHash("Loading");

    public void OnClickButton()
    {
        if(anim)
            anim.SetTrigger(Loading);
        else
            Debug.LogError("An animator is missing.");
        SceneLoader.LoadScene(levelName);
    }
}
