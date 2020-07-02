using System;
using Leap;
using Leap.Unity;
using UnityEngine;
using UnityEngine.Events;

public class HandPalmDetection : MonoBehaviour
{
    [SerializeField] private UnityEvent OnHandsPalmDetected;
    [SerializeField] private UnityEvent OnHandsPalmEndDetected;

    private LeapProvider leapProvider = null;
    private bool detected = false;
    
    private void Awake()
    {
        leapProvider = FindObjectOfType<LeapProvider>();
    }

    private void Update()
    {
        Hand leftHand = leapProvider.CurrentFrame.Hands[0];
        
        Debug.Log(leftHand.PalmNormal);
        
        if (leftHand.PalmNormal == Vector.Down && !detected)
        {
            detected = true;
            OnHandsPalmDetected.Invoke();
        }
        else if (leftHand.PalmNormal != Vector.Down && detected)
        {
            detected = false;
            OnHandsPalmEndDetected.Invoke();
        }
    }
}
