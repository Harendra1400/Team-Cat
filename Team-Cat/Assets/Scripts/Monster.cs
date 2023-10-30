using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public Animator animator;
    private float _speed = 2f;
    public string Retry= "Retry";
    public float delay = 3;
    

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
        if (collision.gameObject.CompareTag("Cat"))
        {
            animator.SetTrigger("monsterStop");
            transform.Translate(Vector3.left * (Time.deltaTime * 0));
            Debug.Log("coliision!!");
            StartCoroutine(LoadLevelAfterDelay(delay)); 
            //LoadNewScene();
        }
    }

    // private void LoadNewScene()
    // {
    //     SceneManager.LoadScene("Retry");
       
    // }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(Retry);
    }
}

