using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retrybutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickOfBtnPlay()
    {
        Debug.Log("-> Btn play");
        SceneManager.LoadScene("Gameplay 1");
    }
}
