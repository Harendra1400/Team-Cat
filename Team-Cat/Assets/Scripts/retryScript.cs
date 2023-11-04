using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class retryScript : MonoBehaviour
{
    [SerializeField] private AudioSource RetryBtnEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadRetry()
    {
        RetryBtnEffect.Play();
        SceneManager.LoadScene("Gameplay");
    }
}
