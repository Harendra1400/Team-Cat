using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    private float _speed = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * _speed));
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            // Load the specified scene.
            Destroy(other.gameObject);
            SceneManager.LoadScene("Retry");
        }
    }
}
