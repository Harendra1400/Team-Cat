using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausebutton : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPaused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }if (Input.GetKeyDown(KeyCode.P)) // You can change the key to any key you want
        {
            TogglePause();
        }


    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // This will effectively "pause" the game by setting the time scale to 0
            // You may want to add additional pause-related logic here, like displaying a pause menu or hiding certain UI elements
        }
        else
        {
            Time.timeScale = 1f; // Set the time scale back to 1 to resume normal gameplay
            // Additional resume-related logic can be added here
        }
    }
}
