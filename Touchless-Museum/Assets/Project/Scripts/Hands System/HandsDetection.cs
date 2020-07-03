using Leap.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class HandsDetection : MonoBehaviour
    {
        private const float TIME_DETECT = 1.5f;
        private TMP_Text handsText = null;
        private float handsDetectionCounter = 1.5f;
        
        private Image loadingImage = null;

        private LeapProvider leapProvider;
        private void OnEnable()
        {
            handsText.enabled = true;
            loadingImage.enabled = true;
            loadingImage.fillAmount = 0;
            handsText.text = "Please put both hands in front of you";
        }

        private void Awake()
        {
            handsText = GetComponentInChildren<TMP_Text>();
            loadingImage = GetComponentInChildren<Image>();

            SceneManager.sceneLoaded += (arg0, mode) =>
            {
                leapProvider = FindObjectOfType<LeapProvider>();
            };
        }

        private void OnDisable()
        {
            // Reset everything
            handsText.enabled = false;
            loadingImage.enabled = false;
        }

        private void LateUpdate()
        {
            if (leapProvider.CurrentFrame.Hands.Count == 2)
            {
                if (!loadingImage.enabled)
                    loadingImage.enabled = true;

                handsDetectionCounter -= Time.deltaTime;
                
                //Change the loading image
                loadingImage.fillAmount = 1 - handsDetectionCounter / TIME_DETECT;

                if (handsDetectionCounter > 0) return;
                
                GameManager.ChangeState(GameState.Tutorial);
                enabled = false;
            }
            else
            {
                if (handsDetectionCounter < TIME_DETECT)
                    handsDetectionCounter = TIME_DETECT;
                loadingImage.fillAmount = 0;
            }
        }
    }
}