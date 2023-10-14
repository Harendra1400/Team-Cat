using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrySwitcher : MonoBehaviour
{
    public string sceneToLoad;

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Cat"))
        {
            // Load the specified scene.
            //Destroy(other.gameObject);
            SceneManager.LoadScene(sceneToLoad);
        }
        else { }
    }
}

