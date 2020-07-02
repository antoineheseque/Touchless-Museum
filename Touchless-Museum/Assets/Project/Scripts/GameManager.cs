using System;
using Project.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private HandsDetection handsDetection = null;
    private TutorialVideo tutorialVideo = null;
    
    private Animator anim = null;
    
    private GameState state = GameState.WaitingForHands;

    private static readonly int Main = Animator.StringToHash("Main");

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        handsDetection = GetComponentInChildren<HandsDetection>();
        tutorialVideo = GetComponentInChildren<TutorialVideo>();
        
        SceneManager.sceneLoaded += (arg0, mode) =>
        {
            anim = GameObject.FindGameObjectWithTag("Animator").GetComponent<Animator>();
        };
    }

    private void Start()
    {
        CheckState();
    }

    public GameState GetState()
    {
        return state;
    }

    public static void ChangeState(GameState newState)
    {
        GameState oldState = _instance.state;
        _instance.state = newState;

        switch (oldState)
        {
            case GameState.WaitingForHands:
                break;
            case GameState.Tutorial:
                _instance.anim.SetTrigger(Main);
                break;
            case GameState.Main:
                break;
            case GameState.Loading:
                break;
            case GameState.Paintings:
                break;
            case GameState.Statues:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        //TODO: Play event ?

        _instance.CheckState();
    }

    public static void Restart()
    {
        ChangeState(GameState.WaitingForHands);
        SceneManager.LoadScene(0);
    }

    private void CheckState()
    {
        switch (state)
        {
            case GameState.WaitingForHands:
                if (!handsDetection.isActiveAndEnabled) handsDetection.enabled = true;
                break;
            case GameState.Tutorial:
                if (!tutorialVideo.isActiveAndEnabled) tutorialVideo.enabled = true;
                break;
            case GameState.Main:
                break;
            case GameState.Loading:
                break;
            case GameState.Paintings:
                break;
            case GameState.Statues:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

