﻿using UnityEngine;

public class SwitchSceneButton : MonoBehaviour
{
    [SerializeField] private string levelName = "Main";
    [SerializeField] private Animator anim = null;
    public void OnClickButton()
    {
        Debug.Log("Button clicked!");
        anim.SetTrigger(levelName);
        SceneLoader.LoadScene(levelName);
    }
}
