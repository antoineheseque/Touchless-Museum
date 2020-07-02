using System;
using Leap.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeChecker : MonoBehaviour
{
    private LeapProvider leapProvider;
    private GameManager gameManager;
    
    private Image loadingImage = null;
    private GameObject alert = null;
    
    private const float TIME_DETECT = 10f;
    private float resetCounter = TIME_DETECT;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();

        alert = transform.GetChild(0).gameObject;
        loadingImage = alert.GetComponentInChildren<Image>();
        alert.SetActive(false);

        SceneManager.sceneLoaded += (arg0, mode) =>
        {
            // Because it will change on each scene
            leapProvider = FindObjectOfType<LeapProvider>();
        };
    }

    private void Update()
    {
        if (leapProvider.CurrentFrame.Hands.Count < 1
            && gameManager.GetState() != GameState.WaitingForHands
            && gameManager.GetState() != GameState.Tutorial
            && gameManager.GetState() != GameState.Loading)
        {
            resetCounter -= Time.deltaTime;

            if (resetCounter > 5) return;
            
            // Show an alert
            if(!alert.activeSelf)
                alert.SetActive(true);
            loadingImage.fillAmount = 1 - resetCounter / (TIME_DETECT-5);
            
            if (resetCounter > 0) return;
            
            Debug.Log("Reset experience due to inactivity.");
            alert.SetActive(false);
            GameManager.Restart();
        }
        else
        {
            if (resetCounter >= TIME_DETECT) return;
            
            resetCounter = TIME_DETECT;
            alert.SetActive(false);
        }
    }
}
