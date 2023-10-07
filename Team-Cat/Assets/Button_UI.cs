using UnityEngine;
using UnityEngine.UI;

public class Button_UI : MonoBehaviour
{
    public Text buttonText; // Reference to the Text component of the button.

    private int clickCount = 0;

    private void Start()
    {
        // Add a listener to the button's click event.
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        clickCount++;
        buttonText.text = "Button Clicked: " + clickCount;
    }
}



