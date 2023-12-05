using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsple : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public Button settings;
    public Button close;
    public GameObject panel;

    public void setting()
    {
        panel.SetActive(true);
    }
    public void closing()
    {
        panel.SetActive(false);
    }
}
