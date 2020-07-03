using UnityEngine;

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
