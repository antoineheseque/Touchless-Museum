using System;
using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Loading text with variable dots
/// </summary>
public class LoadingText : MonoBehaviour
{
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        StartCoroutine(TextDots());
    }

    /// <summary>
    /// Show a loading screen with variable dots
    /// </summary>
    /// <returns></returns>
    private IEnumerator TextDots()
    {
        while (true)
        {
            text.text += ".";
            yield return new WaitForSeconds(.3f);
            text.text = text.text.Replace("...", "");
        }
    }
}
