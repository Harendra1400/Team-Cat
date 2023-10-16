using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public InputField inputField; 
    public Button changeTextButton; 

    // Start is called before the first frame update
    void Start()
    {
        changeTextButton.onClick.AddListener(ChangeInputTextOnClick);
    }

    void ChangeInputTextOnClick()
    {
        string newText = "New Text";  // Change this to your desired text
        inputField.text = newText;
    }


}
