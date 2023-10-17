using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MathAddition : MonoBehaviour
{
    public Text textElement; // Drag and drop the Text element here in the Inspector.
    public string newText = "New Text"; // The new text to set when the button is clicked.

    private void Start()
    {
        Button button = GetComponent<Button>(); // Get the Button component attached to this GameObject.
        
        // Add a click event listener to the button.
        button.onClick.AddListener(ChangeText);
    }

    // This method will be called when the button is clicked.
    private void ChangeText()
    {
        if (textElement != null)
        {
            // Change the text of the Text element.
            textElement.text = newText;
        }
    }
}