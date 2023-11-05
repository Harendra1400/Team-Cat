using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private AudioSource PlayButtonEffect;
    public float delayTime = 0.4f;
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
        PlayButtonEffect.Play();
        Debug.Log("-> Btn play");
        StartCoroutine(LoadSceneAfterDelay());
    }
    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("Gameplay");
    }
}
