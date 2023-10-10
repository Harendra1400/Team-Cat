using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrySwitcher : MonoBehaviour
{
    //public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Cat"))
        {
            // Load the specified scene.
            Destroy(other.gameObject);
            SceneManager.LoadScene("Retry");
        }
        else { }
    }
}

