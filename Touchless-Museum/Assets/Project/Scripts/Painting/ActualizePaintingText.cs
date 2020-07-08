using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Actualize paintings (both texts and gameObjects)
/// </summary>
public class ActualizePaintingText : MonoBehaviour
{
    private const float REMOVE_TIME = .5f;
    private const float SHOW_TIME = 2f;

    [SerializeField] private TMP_Text 
        title = null,
        author = null,
        creationDate = null,
        description = null,
        location = null;

    private Coroutine showTextCoroutine = null;

    [SerializeField] private PaintingScriptableObject paint = null;
    
    private void Start()
    {
        ChangeText(paint);
    }
    
    /// <summary>
    /// Change text details of a painting
    /// </summary>
    /// <param name="painting"></param>
    public void ChangeText(PaintingScriptableObject painting)
    {
        if (showTextCoroutine != null)
        {
            StopAllCoroutines(); // Make sure the remove coroutines are stopped, including the showTextCoroutine
        }
            
        showTextCoroutine = StartCoroutine(ChangeTextCoroutine(painting));
    }

    /// <summary>
    /// Remove all lines at the same time
    /// </summary>
    /// <returns></returns>
    private IEnumerator RemoveAllText()
    {
        int maxCharacter = Mathf.Max(Mathf.Max(Mathf.Max(title.text.Length, author.text.Length), creationDate.text.Length), description.text.Length);
        float timePerCharacter = REMOVE_TIME / maxCharacter;
        float timer = timePerCharacter;
        int rdmChar = 0;
        
        while (maxCharacter > 0)
        {
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                rdmChar = (rdmChar+1)%14;
                
                if (title.text.Length > 0)
                    title.text = title.text.Remove(title.text.Length - 1) + (char)(rdmChar+32);
                if (author.text.Length > 0)
                    author.text = author.text.Remove(author.text.Length - 1) + (char)(rdmChar+32);
                if (creationDate.text.Length > 0)
                    creationDate.text = creationDate.text.Remove(creationDate.text.Length - 1) + (char)(rdmChar+32);
                if (location.text.Length > 0)
                    location.text = location.text.Remove(location.text.Length - 1) + (char)(rdmChar+32);
                if (description.text.Length > 0)
                    description.text = description.text.Remove(description.text.Length - 1) + (char)(rdmChar+32);
                yield return null;
            }

            timer = timePerCharacter;
            maxCharacter -= 1;
            if (title.text.Length > 0)
                title.text = title.text.Remove(title.text.Length - 1);
            if (author.text.Length > 0)
                author.text = author.text.Remove(author.text.Length - 1);
            if (creationDate.text.Length > 0)
                creationDate.text = creationDate.text.Remove(creationDate.text.Length - 1);
            if (location.text.Length > 0)
                location.text = location.text.Remove(location.text.Length - 1);
            if (description.text.Length > 0)
                description.text = description.text.Remove(description.text.Length - 1);
        }

        yield return true;
    }

    private IEnumerator ChangeTextCoroutine(PaintingScriptableObject painting)
    {
        yield return StartCoroutine(RemoveAllText());
        
        // Show text line by line
        int characterCount = painting.paintingName.Length + painting.author.Length + painting.author.Length + painting.location.Length + painting.description.Length;
        int currentCharacter = 0;
        float timePerCharacter = SHOW_TIME / characterCount;
        float timer = timePerCharacter;
        
        while (currentCharacter < characterCount)
        {
            while (timer > 0)
                timer -= Time.deltaTime;

            timer = timePerCharacter;
            
            // Add character to the right text
            TMP_Text selected = TextToSelect(painting, currentCharacter, out char character);
            if(selected) selected.text += character;
            
            currentCharacter++;
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// TODO: Not sure if this is the best way?
    /// Select the right text and index from text to add the right char
    /// </summary>
    /// <param name="painting"></param>
    /// <param name="currentCharacter"></param>
    /// <param name="character"></param>
    /// <returns></returns>
    private TMP_Text TextToSelect(PaintingScriptableObject painting, int currentCharacter, out char character)
    {
        int index = currentCharacter;
        if (index < painting.paintingName.Length)
        {
            character = painting.paintingName[index];
            return title;
        }
        index -= painting.paintingName.Length;

        if (index < painting.author.Length)
        {
            character = painting.author[index];
            return author;
        }
        index -= painting.author.Length;

        if (index < painting.creationDate.Length)
        {
            character = painting.creationDate[index];
            return creationDate;
        }
        index -= painting.creationDate.Length;
        
        if (index < painting.location.Length)
        {
            character = painting.location[index];
            return location;
        }
        index -= painting.location.Length;
        
        if (index < painting.description.Length)
        {
            character = painting.description[index];
            return description;
        }

        character = ' ';
        return null;
    }
}
