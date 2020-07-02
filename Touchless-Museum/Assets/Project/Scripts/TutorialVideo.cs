using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TutorialVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer = null;
    private RawImage image = null;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.targetTexture.Release();
        videoPlayer.enabled = false;

        image = GetComponent<RawImage>();
        
        videoPlayer.loopPointReached += OnEndReached;
    }

    private void OnEnable()
    {
        if (videoPlayer)
        {
            videoPlayer.enabled = true;
            videoPlayer.Play();
            image.enabled = true;
        }
        else
            Debug.LogError("No player.");
    }
    
    private void OnEndReached(VideoPlayer player)
    {
        GameManager.ChangeState(GameState.Main);
        enabled = false;
    }

    private void OnDisable()
    {
        videoPlayer.enabled = false;
        image.enabled = false;
    }
}
