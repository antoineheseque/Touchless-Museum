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

        private GameObject container = null;
        
        private LeapProvider leapProvider;
        private void OnEnable()
        {
            container.SetActive(true);
            loadingImage.fillAmount = 0;
            handsText.text = "Please put both hands in front of you";
        }

        private void Awake()
        {
            container = transform.GetChild(0).gameObject;
            
            handsText = container.GetComponentInChildren<TMP_Text>();
            loadingImage = container.GetComponentsInChildren<Image>()[1];

            SceneManager.sceneLoaded += (arg0, mode) =>
            {
                leapProvider = FindObjectOfType<LeapProvider>();
            };
        }

        private void OnDisable()
        {
            // Reset everything
            container.SetActive(false);
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