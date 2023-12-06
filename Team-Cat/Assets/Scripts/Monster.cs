using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    [SerializeField] private AudioSource MonsterHitEffect;
    public Animator animator1;
    private float _speed = 2f;
   // public string Retry= "Retry";
    //public float delay = 3;
    

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
            animator1.SetTrigger("monsterStop");
            transform.Translate(Vector3.left * (Time.deltaTime * 0));
        }
    }

    private void OnTriggerEnter2D (Collider2D hitInfo)
    {
        //Destroy(gameObject);
        if(hitInfo.CompareTag("Bullet"))
        {
            Debug.Log("bullet hit monster"); 
            Destroy(hitInfo.gameObject);
            MonsterHitEffect.Play();
            animator1.SetTrigger("explode");
            Invoke("Delaydestroy", 1.0f);
            
        }
    }
    private void Delaydestroy()
    {
        Destroy(gameObject);
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cat"))
        {
            animator.SetTrigger("monsterStop");
            //transform.Translate(Vector3.left * (Time.deltaTime * 0));
            Debug.Log("collision!!");
            //StartCoroutine(LoadLevelAfterDelay(delay)); 
            //LoadNewScene();
            Invoke("LoadNewScene", 2.0f);
        }
    }

     private void LoadNewScene()
     {
         SceneManager.LoadScene("Retry");
       
     }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Retry");
    }*/
}

