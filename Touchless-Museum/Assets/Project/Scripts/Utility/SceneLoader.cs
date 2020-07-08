using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Load scenes with a camera move/fade effect
/// </summary>
public class SceneLoader : MonoBehaviour
{
    private GameObject text = null;

    private const float FADE_TIME = 2f;
    private static SceneLoader _instance;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        
        SceneManager.sceneLoaded += (arg0, mode) =>
        {
            // Change text every time scene change
            text = GameObject.FindWithTag("ScreenUI");
            text.SetActive(false);
        };
    }

    private void Start()
    {
        _instance.text.SetActive(false);
    }

    public static void LoadScene(string sceneName)
    {
        GameManager.ChangeState(GameState.Loading);
        _instance.StartCoroutine(_instance.LoadSceneCoroutine(sceneName));
    }

    /// <summary>
    /// Load scene async
    /// </summary>
    /// <param name="sceneName">Level selected</param>
    /// <returns>Nothing</returns>
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        _instance.text.SetActive(true);
        AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(sceneName);
        sceneAsync.allowSceneActivation = false;
        
        yield return new WaitForSeconds(FADE_TIME);

        sceneAsync.allowSceneActivation = true;
    }
}
