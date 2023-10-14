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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collided with a stationary object
        if (collision.gameObject.CompareTag("Cat"))
        {
            transform.Translate(Vector3.left * (Time.deltaTime * 0));
            Debug.Log("coliision!!");
            LoadNewScene();
        }
    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene("Retry");
       
    }
}

