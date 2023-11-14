using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pausemenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pausemenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void quit()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
